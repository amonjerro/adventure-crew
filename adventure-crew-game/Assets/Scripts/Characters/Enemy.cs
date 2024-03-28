using UnityEngine;

public class Enemy : ICharacter
{
    Stats combatStats;
    int xpReward;
    int _initiative = 0;
    public int Initiative
    {
        get => _initiative;
        set => _initiative = value - combatStats.Agility;
    }
    ICombatStrategy aiStrategy;
    Vector3 position;

    public Stats GetStats()
    {
        return combatStats;
    }

    public void Die()
    {
        // Find some way of sending the XP Reward to a collector object
    }

    public void SetStrategy(ICombatStrategy strat)
    {
        aiStrategy = strat;
    }

    public void GetNextAction()
    {
        aiStrategy.DecideNextAction(combatStats);
    }

    public void SetPosition(Vector3 pos)
    {
        position = pos;
    }
}
