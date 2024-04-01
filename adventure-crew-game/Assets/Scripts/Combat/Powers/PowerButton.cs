using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("The Monobehavior acting as a cursor in this scene")]
    public PowerCursor cursor;

    [Tooltip("The cooldown for this power, in seconds")]
    public float cooldownTime;

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

    IEnumerator cooldownRoutine;

    public void EnableCursor()
    {
        IPowerAction action = PowerActionFactory.Make(type);
        action.Effect = powerEffectValue;
        action.Radius = powerRadius;
        cursor.SetAction(action, this);

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

    public void ActivateCooldown()
    {
        Button b = GetComponent<Button>();
        b.interactable = false;
        cooldownRoutine = StartCooldown(b);
        StartCoroutine(cooldownRoutine);
    }

    IEnumerator StartCooldown(Button b)
    {
        yield return new WaitForSeconds(cooldownTime);
        b.interactable = true;
    }
}