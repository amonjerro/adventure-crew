using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FormationController : MonoBehaviour
{
    public int ID;
    public GameObject adventurer;
    private Button selfButton;

    private void Start()
    {
        selfButton = GetComponent<Button>();
        selfButton.onClick.AddListener(GetButtonClicked);
    }
    private void OnDisable()
    {
        selfButton.onClick.RemoveAllListeners();
    }
    public void SetID(int id)
    {
        ID = id;
    }
    private void GetButtonClicked()
    {
        SpawnAdventurer(ID);
        selfButton.interactable = false;
    }
    public void SpawnAdventurer(int id)
    {
        if (AdventurerList.Adventurers[id].GetStats().HP <= 0) return;
        GameObject go = Instantiate(adventurer);
        go.GetComponent<CombatEntityAdventurer>().InititCombatAdventurer(AdventurerList.Adventurers[id].GetStats(), id);
        go.AddComponent<FollowMouse>().FollowMouseInit(this);
    }
    public void ResetButton()
    {
        selfButton.interactable = true;
    }
}
