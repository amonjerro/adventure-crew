using System;

public enum CharacterType
{
    Friend,
    Foe
}


public interface ICharacter : IComparable
{
    public CharacterType Type { get; }
    public int Initiative { get; set; }
    public int CurrentDeployment { get; set; }
    public Stats GetStats();
    public bool isAlive();

    public void Die();

    public void SetStrategy(ICombatStrategy strategy);

    public void GetNextAction();

    int IComparable.CompareTo(object b)
    {
        ICharacter c2 = (ICharacter)b;
        return this.Initiative.CompareTo(c2.Initiative);
    }
}

public abstract class Character : ICharacter
{
    public CharacterType Type { get; private set; }
    public abstract int Initiative { get; set; }
    public abstract int CurrentDeployment { get; set; }
    public abstract Stats GetStats();
    public bool isAlive()
    {
        Stats stats = GetStats();
        return stats.HP >= 0;
    }

    public abstract void Die();

    public abstract void SetStrategy(ICombatStrategy strategy);

    public abstract void GetNextAction();

    int IComparable.CompareTo(object b)
    {
        ICharacter c2 = (ICharacter)b;
        return this.Initiative.CompareTo(c2.Initiative);
    }
}

