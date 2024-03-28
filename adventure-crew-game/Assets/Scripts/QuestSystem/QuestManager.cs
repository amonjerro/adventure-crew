using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    private bool _isEngaged = false;
    private Quest activeQuest;
    [SerializeField]
    QuestUIManager uiManager;

    public bool IsEngaged()
    {
        return _isEngaged;
    }

    public void EngageQuest(Quest q)
    {
        _isEngaged = true;
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
        // Do some Battle shit
        BattleManager bm = GetComponent<BattleManager>();
        Battle b = new Battle();

    }
}