using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityAdventurer : CombatEntity
{
    public void InititCombatAdventurer(Stats stats)
    {
        this.stats = stats;
    }
    protected override void OnStatsChanged()
    {
        base.OnStatsChanged();
    }
}
