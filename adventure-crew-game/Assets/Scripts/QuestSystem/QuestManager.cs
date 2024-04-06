using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    private bool _isEngaged = false;
    private Quest activeQuest;
    private MapLocation activeMapLocation;
    private int encounterIndex;
    [SerializeField]
    QuestUIManager uiManager;

    public bool IsEngaged()
    {
        return _isEngaged;
    }

    public void EngageQuest(Quest q, MapLocation m)
    {
        _isEngaged = true;
        encounterIndex = 0;
        activeQuest = q;
        activeMapLocation = m;
        activeMapLocation.UpdateLocationStatus(MapLocation.LocationStatus.InProgress);
        CombatData.activeQuest = activeQuest;
        CombatData.activeMapLocation = m.GetName();
        CombatData.isQuestEngaged = true;
    }
    

    public void Disengage()
    {
        activeQuest = null;
        _isEngaged = false;
        activeMapLocation.UpdateLocationStatus(MapLocation.LocationStatus.Available);
        activeMapLocation = null;
        CombatData.activeMapLocation = null;
    }

    public QuestUIManager GetManager()
    {
        return uiManager;
    }

    public void LoadNextEncounter()
    {
        CombatData.questEncounterIndex = encounterIndex;
        activeQuest.SetActiveEncounter(encounterIndex);
        activeQuest.StartEncounter();
    }

    public void ProgressQuest()
    {
        encounterIndex++;

        // Show something in the UI?
        if (encounterIndex == activeQuest.encounters.Count)
        {
            // Show this quest has been exhausted
            uiManager.ShowQuestComplete(activeQuest.completionText, activeQuest.questTitle);
            activeQuest.CompleteQuest();
            activeMapLocation.UpdateLocationStatus(MapLocation.LocationStatus.Complete);
            activeQuest = null;
            activeMapLocation = null;
            _isEngaged = false;
            CombatData.isQuestEngaged = false;
            CombatData.activeQuest = null;
            CombatData.questEncounterIndex = 0;
        }
    }

    private void Awake()
    {
        if (CombatData.isQuestEngaged)
        {
            activeQuest = CombatData.activeQuest;
            _isEngaged = true;
            encounterIndex = CombatData.questEncounterIndex;
            activeMapLocation = GetComponent<QuestSelection>().GetMapLocationByName(CombatData.activeMapLocation);
            activeMapLocation.UpdateLocationStatus(MapLocation.LocationStatus.InProgress);
            activeQuest.CompleteEncounter();
            ProgressQuest();
        }
    }
}