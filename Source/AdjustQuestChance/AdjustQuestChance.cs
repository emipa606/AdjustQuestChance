using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace AdjustQuestChance;

internal class AdjustQuestChance : Mod
{
    public static Dictionary<string, float> QuestMap;

    private static Settings latestVersion;

    public AdjustQuestChance(ModContentPack mcp)
        : base(mcp)
    {
        new Harmony("GwinnBleidd.AQC").PatchAll(Assembly.GetExecutingAssembly());
        latestVersion = GetSettings<Settings>() ?? new Settings();
        LongEventHandler.ExecuteWhenFinished(init);
        Settings.CurrentVersion = VersionFromManifest.GetVersionFromModMetaData(mcp.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "Adjust Quest Chance";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        latestVersion.DrawWindow(inRect);
    }

    private static void init()
    {
        compileQuestList();
    }

    private static void compileQuestList()
    {
        QuestMap = new Dictionary<string, float>();
        foreach (var item in DefDatabase<QuestScriptDef>.AllDefsListForReading.Where(q => q.IsRootRandomSelected))
        {
            QuestMap.Add(item.defName, item.rootSelectionWeight);
        }
    }

    public static void ApplyChances()
    {
        foreach (var item in DefDatabase<QuestScriptDef>.AllDefsListForReading.Where(q => q.IsRootRandomSelected))
        {
            if (!latestVersion.QuestChances.TryGetValue(item.defName, out var value))
            {
                continue;
            }

            Debug($"Readjusting: Quest: {item.defName}, new selection weight: {value}");
            item.rootSelectionWeight = value;
        }
    }

    public static void Debug(string title)
    {
        if (latestVersion.DebugMode)
        {
            Log.Message($"AQC: {title}");
        }
    }
}