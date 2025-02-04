using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace AdjustQuestChance;

internal class AdjustQuestChance : Mod
{
    public static Dictionary<string, float> questMap;

    public static Settings LatestVersion;

    public AdjustQuestChance(ModContentPack mcp)
        : base(mcp)
    {
        new Harmony("GwinnBleidd.AQC").PatchAll();
        LatestVersion = GetSettings<Settings>() ?? new Settings();
        LongEventHandler.ExecuteWhenFinished(Init);
        Settings.currentVersion = VersionFromManifest.GetVersionFromModMetaData(mcp.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "Adjust Quest Chance";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        LatestVersion.DrawWindow(inRect);
    }

    private static void Init()
    {
        CompileQuestList();
    }

    public static void CompileQuestList()
    {
        questMap = new Dictionary<string, float>();
        foreach (var item in DefDatabase<QuestScriptDef>.AllDefsListForReading.Where(q => q.IsRootRandomSelected))
        {
            questMap.Add(item.defName, item.rootSelectionWeight);
        }
    }

    public static void applyChances()
    {
        foreach (var item in DefDatabase<QuestScriptDef>.AllDefsListForReading.Where(q => q.IsRootRandomSelected))
        {
            if (!LatestVersion.questChances.TryGetValue(item.defName, out var value))
            {
                continue;
            }

            Debug($"Readjusting: Quest: {item.defName}, new selection weight: {value}");
            item.rootSelectionWeight = value;
        }
    }

    public static void Debug(string title)
    {
        if (LatestVersion.DebugMode)
        {
            Log.Message($"AQC: {title}");
        }
    }
}