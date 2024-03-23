using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocation : MonoBehaviour
{
    [SerializeField]
    private string locationName;

    [SerializeField]
    List<Quest> quests;

    public string LocationName
    {
        get { return locationName; }
    }

    public Quest GetNextQuest()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            if (!quests[i].isQuestComplete())
            {
                return quests[i];
            }
        }
        return null;
    }

}
