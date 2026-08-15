using HarmonyLib;
using JetBrains.Annotations;
using Verse;

namespace AdjustQuestChance;

[HarmonyPatch(typeof(SavedGameLoaderNow), nameof(SavedGameLoaderNow.LoadGameFromSaveFileNow), typeof(string))]
internal static class SavedGameLoaderNow_LoadGameFromSaveFileNow
{
    [UsedImplicitly]
    private static void Postfix()
    {
        AdjustQuestChance.Debug("SavedGameLoaderNow_LoadGameFromSaveFileNow Patch");
        AdjustQuestChance.ApplyChances();
    }
}