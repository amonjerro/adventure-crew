using UnityEngine;

public class Enemy : Character
{
    Stats combatStats;
    int xpReward;
    int _initiative = 0;
    int _currentDeployment = 0;
    public override int Initiative
    {
        get => _initiative;
        set => _initiative = value - combatStats.Agility;
    }

    public override int CurrentDeployment
    {
        get => _currentDeployment;
        set => _currentDeployment = value;
    }

    ICombatStrategy aiStrategy;

    public override Stats GetStats()
    {
        return combatStats;
    }

    public override void Die()
    {
        // Find some way of sending the XP Reward to a collector object
    }

    public override void SetStrategy(ICombatStrategy strat)
    {
        aiStrategy = strat;
    }

    public override void GetNextAction()
    {
        aiStrategy.DecideNextAction(this, combatStats);
    }

    public Enemy(Stats stats, StrategyTypes behaviorType)
    {
        combatStats = stats;
        aiStrategy = CombatStrategyFactory.MakeStrategy(behaviorType);
    }

}
