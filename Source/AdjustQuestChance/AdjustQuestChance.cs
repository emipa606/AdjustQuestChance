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
    private static Settings modSettings;

    public AdjustQuestChance(ModContentPack mcp)
        : base(mcp)
    {
        new Harmony("GwinnBleidd.AQC").PatchAll(Assembly.GetExecutingAssembly());
        LongEventHandler.ExecuteWhenFinished(init);
        Settings.CurrentVersion = VersionFromManifest.GetVersionFromModMetaData(mcp.ModMetaData);
    }

    private static Settings ModSettings =>
        modSettings ??= LoadedModManager.GetMod<AdjustQuestChance>()?.GetSettings<Settings>();

    public static Dictionary<string, float> QuestMap { get; private set; }

    public override string SettingsCategory()
    {
        return "Adjust Quest Chance";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        ModSettings.DrawWindow(inRect);
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
            if (!ModSettings.QuestChances.TryGetValue(item.defName, out var value))
            {
                continue;
            }

            Debug($"Readjusting: Quest: {item.defName}, new selection weight: {value}");
            item.rootSelectionWeight = value;
        }
    }

    public static void Debug(string title)
    {
        if (ModSettings.DebugMode)
        {
            Log.Message($"AQC: {title}");
        }
    }
}