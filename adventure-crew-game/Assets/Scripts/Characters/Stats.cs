using System;
using UnityEngine;

[Serializable]
public struct Stats
{

    public int HP;
    public int MaxHP;
    public int Damage;
    public int Agility;
    public float Range;

    // General Constructor
    public Stats(int hp, int maxHP, int damage, int agility)
    {
        HP = hp;
        MaxHP = maxHP;
        Damage = damage;
        Agility = agility;
        Range = 1.0f;
    }

    // Constructor for ranged units
    public Stats(int hp, int maxHP, int damage, int agility, float rng)
    {
        HP = hp;
        MaxHP = maxHP;
        Damage = damage;
        Agility = agility;
        Range = rng;
    }
}