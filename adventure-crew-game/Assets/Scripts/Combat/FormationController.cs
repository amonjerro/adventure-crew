using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FormationController : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int ID;
    private bool dragging;
    public GameObject adventurer;
    private Button selfButton;

    private void Start()
    {
        selfButton = GetComponent<Button>();
    }
    public void SetID(int id)
    {
        ID = id;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragging) return;
        SpawnAdventurer(ID);
        selfButton.interactable = false;
    }
    public void SpawnAdventurer(int id)
    {
        GameObject go = Instantiate(adventurer);
        go.GetComponent<CombatEntityAdventurer>().InititCombatAdventurer(AdventurerList.Adventurers[id].GetStats());
        go.AddComponent<FollowMouse>().SetID(id);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
    }



}
