using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AData", menuName = "ScriptableObjects/CombatStats", order = 1)]
public class CombatStatsSO : ScriptableObject
{
    public Stats stats;
    public void SetStats(int HP, int maxHP, int Damage, int Agility, float Range)
    {
        stats.HP = HP;
        stats.Damage = Damage;
        stats.Agility = Agility;
        stats.Range = Range;
    }

}
