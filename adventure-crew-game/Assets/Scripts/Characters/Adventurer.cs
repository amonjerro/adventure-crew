
public class Adventurer : Character
{
    private int _initiative = 0;
    private int _currentDeployment = 0;
    Stats combatStats;
    ICombatStrategy aiStrategy;

    public int Exhaustion { get; set; }
    public int XP { get; set; }
    public int Level { get; private set; }
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

    public Adventurer(Stats stats)
    {
        combatStats = stats;
    }

    public override Stats GetStats()
    {
        return combatStats;
    }

    public override void Die()
    {

    }

    public override void SetStrategy(ICombatStrategy strat)
    {
        aiStrategy = strat;
    }

    public override void GetNextAction()
    {
        aiStrategy.DecideNextAction(this, combatStats);
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
