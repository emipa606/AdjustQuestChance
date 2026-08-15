using HarmonyLib;
using JetBrains.Annotations;
using Verse;

namespace AdjustQuestChance;

[HarmonyPatch(typeof(Game), nameof(Game.InitNewGame))]
internal static class Game_InitNewGame
{
    [UsedImplicitly]
    public static void Postfix()
    {
        AdjustQuestChance.Debug("Game_InitNewGame Patch");
        AdjustQuestChance.ApplyChances();
    }
}