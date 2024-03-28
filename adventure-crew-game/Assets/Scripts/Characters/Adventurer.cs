using System;
using UnityEngine;
public class Adventurer : ICharacter
{
    private int _initiative = 0;
    Stats combatStats;
    ICombatStrategy aiStrategy;

    public int Exhaustion { get; set; }
    public int XP { get; set; }
    public int Level { get; private set; }
    public int Initiative
    {
        get => _initiative;
        set => _initiative = value - combatStats.Agility;
    }

    public Adventurer(Stats stats)
    {
        combatStats = stats;
    }

    public Stats GetStats()
    {
        return combatStats;
    }

    public void Die()
    {

    }

    public void SetStrategy(ICombatStrategy strat)
    {
        aiStrategy = strat;
    }

    public void GetNextAction()
    {
        aiStrategy.DecideNextAction(combatStats);
    }

    public void AddXP(int value)
    {
        XP += value;
        int newLevel = ProgressionUtils.CalculateLevel(XP);
        if(newLevel != Level)
        {
            // Level Up
            Level = newLevel;

            // Other bells and whistles, increase stats, etc.
        }
    }

}
