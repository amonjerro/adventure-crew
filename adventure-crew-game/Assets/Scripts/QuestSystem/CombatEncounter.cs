using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObjects/Quests/CombatEncounter")]
public class CombatEncounter : Encounter
{
    //To do: Add enemy entities for combat
    public EnemyFormation enemyFormation;
    public override void OnEnd()
    {

    }


    public override void OnStart()
    {
        CombatData.SetNextFormation(enemyFormation);
        SceneManager.LoadScene(2);
    }

}