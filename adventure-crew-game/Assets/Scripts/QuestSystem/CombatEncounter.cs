using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(2);
    }

}