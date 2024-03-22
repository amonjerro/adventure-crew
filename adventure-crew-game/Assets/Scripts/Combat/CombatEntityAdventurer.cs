using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityAdventurer : CombatEntity
{
    public CombatStatsSO combatStatsSO;

    private void Awake()
    {
        stats = new Stats(combatStatsSO.HP, combatStatsSO.Damage, combatStatsSO.Agility, combatStatsSO.Range);
    }
}
