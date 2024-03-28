using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Quests/CombatEncounter")]
public class CombatEncounter : Encounter
{
    //To do: Add enemy entities for combat
    public EnemyFormation enemyFormation;
    List<Enemy> enemies;
    public override void OnEnd()
    {

    }


    public override void OnStart()
    {
        // Create the enemy objects
        foreach(FormationStruct s in enemyFormation.formation)
        {
            Enemy enemy = new Enemy(s.enemy.stats, s.aiType);
            Stats stats = enemy.GetStats();
            stats.Position = s.position;
            enemies.Add(enemy);
        }

    }

}