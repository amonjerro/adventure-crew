using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum StrategyTypes
{
    Melee,
    Ranged
}

public static class CombatStrategyFactory
{
    public static ICombatStrategy MakeStrategy(StrategyTypes type)
    {
        switch (type)
        {
            case StrategyTypes.Ranged:
                return new RangedStrategy();
            default:
                return new MeleeStrategy();
        }
    }
}

public interface ICombatStrategy
{
    public void FindTarget(ICharacter parent, CharacterType type);
    public void OnTargetFind();
    public void Attack(Stats stats);
    public void Move(Stats stats);
    public void DecideNextAction(ICharacter parent, Stats stats);

}

public abstract class CombatStrategy : ICombatStrategy {
    protected ICharacter target = null;
    public void FindTarget(ICharacter parent, CharacterType type)
    {

        Battle b = BattleManager.Instance.GetBattleByIndex(parent.CurrentDeployment);
        if (type == CharacterType.Foe)
        {
            List<Adventurer> potentialTargets = b.GetAdventurers();
            float minDistance = 999;
            for (int i = 0; i < potentialTargets.Count; i++)
            {
                if (!potentialTargets[i].isAlive())
                {
                    continue;
                }
                Stats stats = potentialTargets[i].GetStats();
                float distanceTest = Vector3.Distance(parent.GetStats().Position, stats.Position);
                if (distanceTest < minDistance)
                {
                    minDistance = distanceTest;
                    target = potentialTargets[i];
                }
            }
        }
        else
        {
            List<Enemy> potentialTargets = b.GetEnemies();
            float minDistance = 999;
            for (int i = 0; i < potentialTargets.Count; i++)
            {
                if (!potentialTargets[i].isAlive())
                {
                    continue;
                }
                Stats stats = potentialTargets[i].GetStats();
                float distanceTest = Vector3.Distance(parent.GetStats().Position, stats.Position);
                if (distanceTest < minDistance)
                {
                    minDistance = distanceTest;
                    target = potentialTargets[i];
                }
            }
        }
    }

    public abstract void OnTargetFind();

    public void Attack(Stats stats)
    {
        Stats targetStats = target.GetStats();
        targetStats.HP -= stats.Damage;
    }

    public abstract void Move(Stats stats);
    

    public void DecideNextAction(ICharacter parent, Stats stats)
    {
        if (target == null)
        {
            FindTarget(parent, parent.Type);
        }

        if (Vector3.Distance(stats.Position, target.GetStats().Position) > stats.Range)
        {
            Move(stats);
        }
        else
        {
            Attack(stats);
        }
    }
}


public class MeleeStrategy : CombatStrategy
{
    public override void OnTargetFind()
    {
        return;
    }
    public override void Move(Stats stats)
    {
        Vector3 direction = target.GetStats().Position - stats.Position;
        stats.Position = stats.Position + direction * stats.Agility;
    }
}

public class RangedStrategy : CombatStrategy
{

    float directionModifier = 1;

    public override void OnTargetFind() { }

    public override void Move(Stats stats)
    {

        float distanceToTarget = Vector3.Distance(stats.Position, target.GetStats().Position);
        if (distanceToTarget < stats.Range * 0.5f)
        {
            directionModifier = -1;
        } else
        {
            directionModifier = 1;
        }

        Vector3 direction = target.GetStats().Position - stats.Position;
        direction *= directionModifier;
        stats.Position = stats.Position + direction * stats.Agility;
    }
}