using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOs/Quest")]
public class Quest : ScriptableObject
{
    [TextArea]
    public string description;
    public string questTitle;

    public List<Encounter> encounters;
    private Encounter activeEncounter;
}
