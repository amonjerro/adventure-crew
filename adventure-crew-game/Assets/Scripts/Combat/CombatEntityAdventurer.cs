using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityAdventurer : CombatEntity
{
    public int id;
    public void InititCombatAdventurer(Stats stats, int id)
    {
        this.stats = stats;
        this.id = id;
    }
    protected override void OnStatsChanged()
    {
        base.OnStatsChanged();
        AdventurerList.Adventurers[id].SetStats(stats);
    }
}
