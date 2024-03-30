using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerCursor : MonoBehaviour
{
    public Vector2 mouseSensitivity;
    public float xClamp, zClamp;
    IPowerAction activeAction;
    private bool _isActionSet = false;
    private Vector3 center = Vector3.zero;

    [SerializeField]
    Color friendlyColor;
    [SerializeField]
    Color unFriendlyColor;

    [SerializeField]
    private GameObject powerCylinder;
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