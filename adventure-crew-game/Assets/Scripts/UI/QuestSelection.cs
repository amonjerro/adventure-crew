using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestSelection : MonoBehaviour
{
    [SerializeField]
    private Transform targetLocation;
    private float targetX;
    private float targetY;
    private string targetName;
    [SerializeField]
    private Transform currentMapLocation;
    private string currentLocationName;

    [SerializeField]
    private List<MapLocation> mapLocations;

    // Start is called before the first frame update
    void Start()
    {
        //Set Location of the CurrentMapLocation
        currentLocationName = "plains";//Placeholder

        //Set the X for the current location as inactive because the O will be there instead
        for(int i = 0; i < mapLocations.Count; i++)
        {
            if(mapLocations[i].LocationName == currentLocationName)
            {
                mapLocations[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets the player icon's position to the position of the button clicked, offset slightly
    public void MovePlayer()
    {
        targetX = EventSystem.current.currentSelectedGameObject.transform.position.x - 15;
        targetY = EventSystem.current.currentSelectedGameObject.transform.position.y - 15;
        targetLocation.position = new Vector3(targetX, targetY, targetLocation.position.z);
        targetName = EventSystem.current.currentSelectedGameObject.GetComponent<MapLocation>().LocationName;
    }
}
