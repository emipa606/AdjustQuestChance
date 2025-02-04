using HarmonyLib;
using Verse;

namespace AdjustQuestChance;

[HarmonyPatch(typeof(SavedGameLoaderNow), nameof(SavedGameLoaderNow.LoadGameFromSaveFileNow), typeof(string))]
internal class SavedGameLoaderNow_LoadGameFromSaveFileNow
{
    private static void Postfix()
    {
        AdjustQuestChance.Debug("SavedGameLoaderNow_LoadGameFromSaveFileNow Patch");
        AdjustQuestChance.applyChances();
    }
}