using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace AdjustQuestChance;

internal class Settings : ModSettings
{
    private static Vector2 scrollPosition = Vector2.zero;

    private static readonly bool debugMode = false;

    public static string currentVersion;

    public bool DebugMode = debugMode;

    public Dictionary<string, float> questChances = new Dictionary<string, float>();

    public override void ExposeData()
    {
        Scribe_Values.Look(ref DebugMode, "DebugMode", debugMode);
        Scribe_Collections.Look(ref questChances, "questChances");
        if (questChances == null)
        {
            questChances = new Dictionary<string, float>();
        }
    }

    public void Reset()
    {
        DebugMode = debugMode;
        questChances.Clear();
    }

    public void DrawWindow(Rect inRect)
    {
        inRect.yMin += 20f;
        inRect.yMax -= 20f;
        var listing_Standard = new Listing_Standard();
        var outRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
        var rect = new Rect(0f, 0f, inRect.width - 30f, 150 + (questChances.Count * 50));
        Widgets.BeginScrollView(outRect, ref scrollPosition, rect);
        listing_Standard.Begin(rect);
        if (listing_Standard.ButtonText("AQC.Reset".Translate()))
        {
            Reset();
        }

        listing_Standard.GapLine();
        listing_Standard.Label("AQC.Reload".Translate());
        listing_Standard.GapLine();
        listing_Standard.CheckboxLabeled("AQC.Debug".Translate(), ref DebugMode);
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("AQC.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.GapLine();
        foreach (var item in AdjustQuestChance.questMap)
        {
            if (!questChances.TryGetValue(item.Key, out var value))
            {
                value = item.Value;
            }

            listing_Standard.Label("AQC.ItemInfo".Translate(item.Key, Math.Round(value, 3)));

            questChances[item.Key] = listing_Standard.Slider(value, 0.1f, 20f);
        }

        listing_Standard.GapLine();
        listing_Standard.Label("AQC.Reload".Translate());
        listing_Standard.GapLine();
        listing_Standard.End();
        Widgets.EndScrollView();
        Write();
    }
}