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

    public void CompleteQuest()
    {
        _isComplete = true;
    }

    public bool isQuestComplete()
    {
        return _isComplete;
    }
}
