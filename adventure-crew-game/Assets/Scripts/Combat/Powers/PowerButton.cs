using UnityEngine;
using UnityEngine.EventSystems;

public class PowerButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("The Monobehavior acting as a cursor in this scene")]
    public PowerCursor cursor;

    [Tooltip("The size of the power cylinder and it's area of effect")]
    public int powerRadius;

    [Tooltip("Either the value of the heal or the duration of the buff/debuff, as appropriate")]
    public int powerEffectValue;

    [Tooltip("The Monobehavior object acting as a tooltip")]
    public Tooltip tooltip;

    [Tooltip("The description that will show up in the tooltip")]
    public string powerDescription;

    [Tooltip("What type of power this is")]
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