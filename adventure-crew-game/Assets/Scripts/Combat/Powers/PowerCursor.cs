using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerCursor : MonoBehaviour
{
    [Tooltip("How much to scale the mouse sensitivity by. Good values are between 0.01 and 0.2")]
    public Vector2 mouseSensitivity;

    [Tooltip("The limits of the field. Should match the combat plane size")]
    public float xClamp, zClamp;
    IPowerAction activeAction;
    private bool _isActionSet = false;
    private Vector3 center = Vector3.zero;

    [Tooltip("What color is the cylinder going to be for allied-oriented powers")]
    [SerializeField]
    Color friendlyColor;

    [Tooltip("What color is the cylinder going to be for enemy-oriented powers")]
    [SerializeField]
    Color unFriendlyColor;

    [Tooltip("The Power Cylinder prefab")]
    [SerializeField]
    private GameObject powerCylinder;

    [Tooltip("The Power Cylinder material. Has its own shader")]
    [SerializeField]
    private Material powerCylinderMaterial;

    public void SetAction(IPowerAction action)
    {
        activeAction = action;
        _isActionSet = true;
        powerCylinder.SetActive(true);
        powerCylinder.transform.localScale = new Vector3(action.Radius, 1, action.Radius);
        if (activeAction.GetTarget() == PowerTarget.Adventurers)
        {
            powerCylinderMaterial.SetColor("_PowerColor", friendlyColor);
        } else
        {
            powerCylinderMaterial.SetColor("_PowerColor", unFriendlyColor);
        }
    }

    public void Execute()
    {

        if (!_isActionSet)
        {
            return;
        }
        _isActionSet = false;
        List<CombatEntity> targets;

        // Narrow down to those inside the power sphere
        if (activeAction.GetTarget() == PowerTarget.Adventurers)
        {
            targets = CombatManager.Instance.adventurers.FindAll(delegate (CombatEntity ce) {
                return Vector3.Distance(ce.transform.position, center) * 2f < activeAction.Radius;
            });
        } else
        {
            targets = CombatManager.Instance.enemies.FindAll(delegate (CombatEntity ce) {
                return Vector3.Distance(ce.transform.position, center) * 2f < activeAction.Radius;
            });
        }
        // Do eet
        activeAction.DoPower(targets);
        powerCylinder.SetActive(false);
    }

    private void Update()
    {
        powerCylinder.transform.position = center;
    }

    // Mouse controls adapted from Between Root and Bough and originally implemented by Jared Goronkin
    private void OnLook(InputValue value)
    {
        float adjustedXClamp = xClamp - powerCylinder.transform.localScale.x * 0.5f;
        float adjustedZClamp = zClamp - powerCylinder.transform.localScale.z * 0.5f;
        Vector2 input = Vector2.Scale(value.Get<Vector2>(), mouseSensitivity);
        center = new Vector3(Mathf.Clamp(center.x + input.x, -adjustedXClamp, adjustedXClamp), 1, Mathf.Clamp(center.z + input.y, -adjustedZClamp, adjustedZClamp));
    }

    private void OnExecuteAction(InputValue value)
    {
        Execute();
    }

}