using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityEnemy : CombatEntity
{
    public int iniHP;
    public int maxHP;
    public int Damage;
    public int Agility;
    public float Range;

    private void Awake()
    {
        stats = new Stats(iniHP, maxHP, Damage, Agility, Range);
    }
}
