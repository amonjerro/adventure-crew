
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestSelection : MonoBehaviour
{
    [SerializeField]
    private Transform targetLocation;
    Vector2 targetPosition;
    private string targetName;
    [SerializeField]
    private Transform currentMapLocation;
    private string currentLocationName;
    QuestManager qm;
    bool qmFound = false;

    [SerializeField]
    private List<MapLocation> mapLocations;
    private MapLocation tentativeMapLocation;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (!qmFound)
        {
            qm = GetComponent<QuestManager>();
            qmFound = true;
        }
        if (CombatData.lastCombatWon)
        {   
            targetLocation.position = CombatData.lastMapLocation;
            QuestUIManager uiManager = qm.GetManager();
            uiManager.gameObject.SetActive(true);
            uiManager.ShowEncounterButton();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets the player icon's position to the position of the button clicked, offset slightly
    public void MovePlayer()
    {

        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
        float targetX = selectedObject.transform.position.x - 15;
        float targetY = selectedObject.transform.position.y - 15;
        targetPosition = new Vector2(targetX, targetY);
        tentativeMapLocation = selectedObject.GetComponent<MapLocation>();
        if (!qmFound)
        {
            qm = GetComponent<QuestManager>();
            qmFound = true;
        }
        if (qm.IsEngaged() && tentativeMapLocation.GetNextQuest() != CombatData.activeQuest)
        {
            QuestUIManager uiManager = qm.GetManager();
            uiManager.gameObject.SetActive(true);
            uiManager.ShowDisengage();
            return;
        }

        // Otherwise, just do the move
        EffectMove();
        
    }

    public void EffectMove()
    {
        targetLocation.position = new Vector3(targetPosition.x, targetPosition.y, targetLocation.position.z);
        targetName = tentativeMapLocation.LocationName;
        Quest q = tentativeMapLocation.GetNextQuest();
        if (q  == null)
        {
            // Inform no quests remain
            QuestUIManager uiManager = qm.GetManager();
            uiManager.gameObject.SetActive(true);
            uiManager.ShowNoQuests();
        } else
        {
            // Show the quest information
            QuestUIManager uiManager = qm.GetManager();
            uiManager.gameObject.SetActive(true);
            uiManager.UpdateUI(q, tentativeMapLocation);
        }
        CombatData.lastMapLocation = targetLocation.position;
    }

    public MapLocation GetMapLocationByName(string name)
    {
        for (int i = 0; i < mapLocations.Count; i++)
        {
            if (mapLocations[i].GetName() == name)
            {
                return mapLocations[i];
            }
        }
        return null;
    }
}
