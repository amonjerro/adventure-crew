using JetBrains.Annotations;
using UnityEngine;

public static class CombatData
{
    public static bool isQuestEngaged = false;
    public static int questEncounterIndex = 0;
    public static Vector3 lastMapLocation;
    public static Quest activeQuest;
    public static bool lastCombatWon = false;
    public static EnemyFormation activeEnemyFormation;
    public static void SetNextFormation(EnemyFormation formation)
    {
        activeEnemyFormation = formation;
    }

    public static void Reset()
    {
        isQuestEngaged = false;
        questEncounterIndex = 0;
        lastMapLocation = Vector3.zero;
        activeQuest = null;
        lastCombatWon = false;
        activeEnemyFormation = null;
    }
}