public class Adventurer : ICharacter
{
    Stats combatStats;
    ICombatStrategy aiStrategy;
    public float Exhaustion { get; set; }
    public int XP { get; set; }
    public int Level { get; private set; }
    public bool OnQuest { get; set; }
    public float HealInterval { get; private set; }

    public enum Rank
    {
        Expert = 4,
        Veteran = 3,
        Seasons = 2,
        Journeyman = 1,
        Novice = 0

    }
    public Rank rank { get; set; }

    public Adventurer(Stats stats)
    {
        combatStats = stats;
    }

    public Stats GetStats()
    {
        return combatStats;
    }
    public void SetStats(Stats stats)
    {
        this.combatStats = stats;
    }

    public void Die()
    {
        AdventurerList.Adventurers.Remove(this);
        AdventurerList.QuickSort(ref AdventurerList.Adventurers, 0, AdventurerList.Adventurers.Count - 1);
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

    /// <summary>
    /// If the Adventurers were just on a quest, they get more exhausted based on how much HP they have left.
    /// If they were not on a quest, they regain exhaustion as a substitute for our wait time for the playtest.
    /// </summary>
    public void AdjustExhaustion()
    {
        if (OnQuest)
        {
            Exhaustion += (int)(50f * ((combatStats.MaxHP + 1 - combatStats.HP) / combatStats.MaxHP));
            OnQuest = false;
            HealInterval = (combatStats.MaxHP - combatStats.HP + 1) / Exhaustion;
            if(Exhaustion >= 100)
            {
                Die();
            }
        }
        //else
        //{
        //    Exhaustion -= 20;
           
        //    if (Exhaustion < 0)
        //        Exhaustion = 0;
        //}
    }
}
