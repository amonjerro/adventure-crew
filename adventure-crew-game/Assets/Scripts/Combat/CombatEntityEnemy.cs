using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEntityEnemy : CombatEntity
{
    public CombatStatsSO enemyStats;
    public int iniHP;
    public int maxHP;
    public int Damage;
    public int Agility;
    public float Range;

    private void Setup()
    {
        stats = new Stats(iniHP, maxHP, Damage, Agility, Range);
    }

    private void Awake()
    {
        Setup();
    }

    public void SetStats(CombatStatsSO statsData)
    {
        enemyStats = statsData;
        stats = new Stats(enemyStats.stats.MaxHP, enemyStats.stats.MaxHP, enemyStats.stats.Damage, enemyStats.stats.Agility, enemyStats.stats.Range);
    }
}
