public class Enemy : ICharacter
{
    Stats combatStats;
    int xpReward;
    ICombatStrategy aiStrategy;

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
}
