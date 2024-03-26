
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/EnemyFormation")]
public class EnemyFormation : ScriptableObject
{
    public List<FormationStruct> formation;

}

public struct FormationStruct
{

    public CombatStatsSO enemy;
    public Vector3 position;

}