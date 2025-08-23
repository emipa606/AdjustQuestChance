using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace AdjustQuestChance;

internal class Settings : ModSettings
{
    private const bool debugMode = false;
    private static Vector2 scrollPosition = Vector2.zero;

    public static string CurrentVersion;

    public bool DebugMode = debugMode;

    public Dictionary<string, float> QuestChances = new();
    private string searchText = string.Empty;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref DebugMode, "DebugMode");
        Scribe_Collections.Look(ref QuestChances, "questChances");
        QuestChances ??= new Dictionary<string, float>();
    }

    private void reset()
    {
        DebugMode = debugMode;
        QuestChances.Clear();
    }

    public void DrawWindow(Rect inRect)
    {
        inRect.yMin += 20f;
        inRect.yMax -= 20f;
        var listingStandard = new Listing_Standard();
        var outRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
        var rect = new Rect(0f, 0f, inRect.width - 30f, 150 + (QuestChances.Count * 50));
        Widgets.BeginScrollView(outRect, ref scrollPosition, rect);
        listingStandard.Begin(rect);
        if (listingStandard.ButtonText("AQC.Reset".Translate()))
        {
            reset();
        }

        listingStandard.GapLine();
        listingStandard.Label("AQC.Reload".Translate());
        listingStandard.GapLine();
        listingStandard.CheckboxLabeled("AQC.Debug".Translate(), ref DebugMode);
        if (CurrentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("AQC.ModVersion".Translate(CurrentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.GapLine();
        searchText = listingStandard.TextEntryLabeled("AQC.Search".Translate(), searchText);

        IEnumerable<KeyValuePair<string, float>> items = AdjustQuestChance.QuestMap;
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            var term = searchText.Trim();
            items = items.Where(pair => pair.Key.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        if (items?.Any() == true)
        {
            foreach (var item in items.OrderBy(pair => pair.Key))
            {
                if (!QuestChances.TryGetValue(item.Key, out var value))
                {
                    value = item.Value;
                }

                listingStandard.Label("AQC.ItemInfo".Translate(item.Key, Math.Round(value, 3)));

                QuestChances[item.Key] = listingStandard.Slider(value, 0.1f, 20f);
            }
        }

        listingStandard.GapLine();
        listingStandard.Label("AQC.Reload".Translate());
        listingStandard.GapLine();
        listingStandard.End();
        Widgets.EndScrollView();
        Write();
    }
}