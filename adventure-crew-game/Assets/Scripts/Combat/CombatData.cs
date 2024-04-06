using System.Collections.Generic;
using UnityEngine;

public static class CombatData
{
    public static bool isQuestEngaged = false;
    public static int questEncounterIndex = 0;
    public static Vector3 lastMapLocation;
    public static Dictionary<string, MapLocation.LocationStatus> statuses = new Dictionary<string, MapLocation.LocationStatus>();
    public static Quest activeQuest;
    public static string activeMapLocation;
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
        statuses.Clear();
        activeMapLocation = "";
        activeEnemyFormation = null;
    }

    public static MapLocation.LocationStatus GetLocationStatus(string key)
    {
        MapLocation.LocationStatus outResult;
        if(statuses.TryGetValue(key, out outResult))
        {
            return outResult;
        }
        statuses.Add(key, MapLocation.LocationStatus.Available);
        return MapLocation.LocationStatus.Available;
    }
}