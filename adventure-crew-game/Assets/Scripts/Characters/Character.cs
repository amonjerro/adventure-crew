using System;
using System.Collections;
using UnityEngine;

public interface ICharacter : IComparable
{

    public int Initiative { get; set; }
    public Stats GetStats();
    public void Die();

    public void SetStrategy(ICombatStrategy strategy);

    public void GetNextAction();

    public void SetPosition(Vector3 pos);

    int IComparable.CompareTo(object b)
    {
        ICharacter c2 = (ICharacter)b;
        return this.Initiative.CompareTo(c2.Initiative);
    }
    
}

