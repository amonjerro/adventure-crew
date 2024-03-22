using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AData", menuName = "ScriptableObjects/CombatStats", order = 1)]
public class CombatStatsSO : ScriptableObject
{
    public int HP;
    public int Damage;
    public int Agility;
    public float Range;

}
