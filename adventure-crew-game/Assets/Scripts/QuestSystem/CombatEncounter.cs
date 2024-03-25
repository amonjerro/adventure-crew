using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOs/CombatEncounter")]
public class CombatEncounter : Encounter
{
    //To do: Add enemy entities for combat
    public List<CombatStatsSO> enemies;

    public override void OnEnd()
    {

    }


    public override void OnStart()
    {

    }

    public override int CalculateXPReward()
    {
        int sum = 0;
        foreach(CombatStatsSO enemy in enemies)
        {
            sum += enemy.xp;
        }
        return sum;
    }
}