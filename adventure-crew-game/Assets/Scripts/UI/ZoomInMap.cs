using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInMap : MonoBehaviour
{
    public void ZoomIn(RectTransform location)
    {
        RectTransform map = this.GetComponent<RectTransform>();
        map.anchoredPosition = new Vector2(-2*location.anchoredPosition.x, -2*location.anchoredPosition.y);
        this.transform.localScale = new Vector3(2, 2, 2);
    }
}
