using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityAdventurer : CombatEntity
{
    [Header("Assign a scriptable object")]
    public CombatStatsSO combatStatsSO;

    [Header("For testing")]
    public bool Debug = false;
    private void Awake()
    {
        stats = new Stats(combatStatsSO.stats.HP, combatStatsSO.stats.MaxHP, combatStatsSO.stats.Damage, combatStatsSO.stats.Agility, combatStatsSO.stats.Range);
    }
    protected override void OnStatsChanged()
    {
        base.OnStatsChanged();

        if (Debug) return;
        
        combatStatsSO.SetStats(stats.HP, stats.MaxHP, stats.Damage, stats.Agility, stats.Range);
    }
}
