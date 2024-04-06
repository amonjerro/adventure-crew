using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowMouse : MonoBehaviour
{
    private FormationController controller;
    public bool withinBoundary = false;
    public void FollowMouseInit(FormationController controller)
    {
        this.controller = controller;
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layer_mask = LayerMask.GetMask("Formation");
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer_mask))
        {
            transform.position = hit.point;
            withinBoundary = true;
        }
        else withinBoundary = false;
    }
    public static Action ReadyToFight;
    //This action is subscribed by: CombatStageController

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!withinBoundary) return;
            AdventurerList.Adventurers[controller.ID].OnQuest = true;
            this.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (ReadyToFight != null) ReadyToFight();
            Destroy(this);
        }
        if(Input.GetMouseButtonDown(1))
        {
            controller.ResetButton();
            Destroy(gameObject);
        }
    }
}
