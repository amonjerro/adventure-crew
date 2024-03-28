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
        activeQuest.SetActiveEncounter(encounterIndex);
        activeQuest.StartEncounter();
        // Do some Battle shit
        BattleManager bm = GetComponent<BattleManager>();
        Battle b = new Battle();

    }
}