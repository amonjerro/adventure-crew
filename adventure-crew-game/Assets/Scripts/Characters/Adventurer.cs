public class Adventurer : ICharacter
{
    Stats combatStats;
    ICombatStrategy aiStrategy;
    public int Exhaustion { get; set; }
    public int XP { get; set; }
    public int Level { get; private set; }

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
