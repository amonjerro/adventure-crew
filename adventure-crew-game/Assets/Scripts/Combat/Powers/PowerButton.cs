using UnityEngine;
using UnityEngine.EventSystems;

public class PowerButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PowerCursor cursor;
    public int powerRadius;
    public int powerEffectValue;
    public Tooltip tooltip;
    public string powerDescription;
    public PowerType type;

    public void EnableCursor()
    {
        IPowerAction action = PowerActionFactory.Make(type);
        action.Effect = powerEffectValue;
        action.Radius = powerRadius;
        cursor.SetAction(action);
    }
    
    public void OnPointerEnter(PointerEventData data)
    {
        tooltip.SetText(powerDescription);
        tooltip.Show(GetComponent<RectTransform>().localPosition);
    }

    public void OnPointerExit(PointerEventData data)
    {
        tooltip.Hide();
    }
}