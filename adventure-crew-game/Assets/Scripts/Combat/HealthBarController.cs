using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Material _mat;
    public float test;
    void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }
    private void OnEnable()
    {
        GetComponentInParent<CombatEntity>().StatsChanged += UpdateHealthBar;
    }
    private void OnDisable()
    {
        if(GetComponentInParent<CombatEntity>() != null)
        {
            UnsubscribeEvents();
        }
    }
    public void UnsubscribeEvents()
    {
        GetComponentInParent<CombatEntity>().StatsChanged -= UpdateHealthBar;
    }

    private void Update()
    {
        test = _mat.GetFloat("_Health");
    }
    private void UpdateHealthBar(float HP, float maxHP)
    {
        //print(gameObject.name + " update health bar: " + HP / maxHP);
        _mat.SetFloat("_Health", HP / maxHP);
    }
}
