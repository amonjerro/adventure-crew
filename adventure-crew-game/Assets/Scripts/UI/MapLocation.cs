using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LocationStatus
{
    QuestAvailable,
    QuestInProgress,
    QuestLost,
    QuestWon
}

public class MapLocation : MonoBehaviour
{
    [SerializeField]
    private string locationName;

    [SerializeField]
    List<Quest> quests;

    [SerializeField]
    public LocationStatus currentStatus;

    public List<Sprite> statusIcons;

    [SerializeField]
    QuestSelection questSelectionObject;


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

    public void ChangeStatus(LocationStatus target)
    {
        currentStatus = target;
        Image objectImage = GetComponent<Image>();
        switch (target)
        {
            case LocationStatus.QuestInProgress:
                objectImage.sprite = statusIcons[1];
                break;
            case LocationStatus.QuestWon:
                objectImage.sprite = statusIcons[2];
                break;
            case LocationStatus.QuestLost:
                objectImage.sprite = statusIcons[3];
                break;
            default:
                objectImage.sprite = statusIcons[0];
                break;

        }
    }

    public void SelectionAction()
    {
        SelectionActions actionType;
        if (currentStatus == LocationStatus.QuestAvailable)
        {
            actionType = SelectionActions.MovePlayer;
        } else
        {
            actionType = SelectionActions.RenderBattle;
        }
        ILocationSelectAction action = ActionFactory.MakeLocationAction(actionType);
        action.Perform(questSelectionObject);

    }
}
