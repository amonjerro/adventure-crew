using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FormationController : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool dragging;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragging) return;
        FormationManager.Instance.SpawnAdventurer();
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
