
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(menuName = "ScriptableObjects/EnemyFormation")]
public class EnemyFormation : ScriptableObject
{
    public List<FormationStruct> formation;
}

[Serializable]
public struct FormationStruct
{

    public CombatStatsSO enemy;
    public Vector3 position;
    public Vector3 scale;

}