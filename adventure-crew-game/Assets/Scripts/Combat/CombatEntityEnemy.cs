using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityEnemy : CombatEntity
{
    public int HP;
    public int Damage;
    public int Agility;
    public float Range;

    private void Awake()
    {
        stats = new Stats(HP, Damage, Agility, Range);
    }
}