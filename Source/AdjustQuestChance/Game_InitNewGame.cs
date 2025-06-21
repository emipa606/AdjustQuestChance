using HarmonyLib;
using Verse;

namespace AdjustQuestChance;

[HarmonyPatch(typeof(Game), nameof(Game.InitNewGame))]
internal static class Game_InitNewGame
{
    public static void Postfix()
    {
        AdjustQuestChance.Debug("Game_InitNewGame Patch");
        AdjustQuestChance.ApplyChances();
    }
}