using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    private bool _isEngaged = false;
    private Quest activeQuest;
    private int encounterIndex;
    [SerializeField]
    QuestUIManager uiManager;

    public bool IsEngaged()
    {
        return _isEngaged;
    }

    public void EngageQuest(Quest q)
    {
        _isEngaged = true;
        encounterIndex = 0;
        activeQuest = q;
        CombatData.activeQuest = activeQuest;
        CombatData.isQuestEngaged = true;
    }
    

    public void Disengage()
    {
        activeQuest = null;
        _isEngaged = false;
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
            uiManager.ShowQuestComplete(activeQuest.completionText);
            activeQuest.CompleteQuest();
            activeQuest = null;
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

            activeQuest.CompleteEncounter();
            ProgressQuest();
        }
    }
}