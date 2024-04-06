using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLocation : MonoBehaviour
{
    public enum LocationStatus
    {
        Available,
        InProgress,
        Complete
    }

    public LocationStatus status = LocationStatus.Available;

    [SerializeField]
    List<Sprite> locationIcons;

    [SerializeField]
    private string locationName;

    [SerializeField]
    List<Quest> quests;

    public string LocationName
    {
        get { return locationName; }
    }

    private void OnEnable()
    {
        UpdateLocationStatus(CombatData.GetLocationStatus(locationName));
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

    public void UpdateLocationStatus(LocationStatus newStatus)
    {
        status = newStatus;
        CombatData.statuses[locationName] = newStatus;
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        Image locationImage = GetComponent<Image>();
        switch (status)
        {
            case LocationStatus.InProgress:
                locationImage.sprite = locationIcons[1];
                break;
            case LocationStatus.Complete:
                locationImage.sprite = locationIcons[2];
                break;
            default:
                locationImage.sprite = locationIcons[0];
                break;
        }
        return;
    }

    public string GetName()
    {
        return locationName;
    }

}
