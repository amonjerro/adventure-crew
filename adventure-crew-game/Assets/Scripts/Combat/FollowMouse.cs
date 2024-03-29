using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowMouse : MonoBehaviour
{
    public int ID;
    public void SetID(int id)
    {
        ID = id;
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layer_mask = LayerMask.GetMask("Formation");
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer_mask))
        {
            transform.position = hit.point;
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Destroy(this);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }
}
