using System;
using UnityEngine;

public interface ICharacter : IComparable
{

    public int Initiative { get; set; }
    public Stats GetStats();
    public bool isAlive()
    {
        Stats stats = GetStats();
        return stats.HP >= 0;
    }

    public void Die();

    public void SetStrategy(ICombatStrategy strategy);

    public void GetNextAction();

    int IComparable.CompareTo(object b)
    {
        ICharacter c2 = (ICharacter)b;
        return this.Initiative.CompareTo(c2.Initiative);
    }
    
}

