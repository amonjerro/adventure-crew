using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOs/Quest")]
public class Quest : ScriptableObject
{
    [TextArea]
    public string description;
    public string questTitle;
    private bool _isComplete = false;

    public List<Encounter> encounters;
    private Encounter activeEncounter;
    [SerializeField]
    public Reward reward;

    public void CompleteQuest()
    {
        _isComplete = true;
    }

    public bool isQuestComplete()
    {
        return _isComplete;
    }

    public void SetActiveEncounter(int index)
    {
        activeEncounter = encounters[index];
    }

    public int PreviewReward()
    {
        return reward.gold;
    }

    public Reward CompleteEncounter()
    {
        activeEncounter.OnEnd();
        return reward;
    }

    public void StartEncounter()
    {
        activeEncounter.OnStart();
    }
}
