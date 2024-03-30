using System.Collections;
using System.Collections.Generic;

public enum PowerType
{
    Heal,
    Buff,
    Debuff
}

public enum PowerTarget
{
    Adventurers,
    Enemies
}

public static class PowerActionFactory
{
    public static IPowerAction Make(PowerType type)
    {
        switch (type)
        {
            case PowerType.Buff:
                return new BuffPower();
            case PowerType.Debuff:
                return new DebuffPower();
            default:
                return new HealPower();
        }
    }
}

public interface IPowerAction
{
    public int Radius { get; set; }
    public int Effect { get; set; }
    public void DoPower(List<CombatEntity> targets);
    public PowerTarget GetTarget();
}

public abstract class PowerAction : IPowerAction
{
    public PowerTarget powerTarget;
    private int _radius;
    private int _effect;
    public int Radius { get => _radius; set => _radius = value; }
    public int Effect { get => _effect; set => _effect = value; }
    public abstract void DoPower(List<CombatEntity> targets);
    public PowerTarget GetTarget()
    {
        return powerTarget;
    }

}

public class HealPower : PowerAction
{
    public HealPower()
    {
        powerTarget = PowerTarget.Adventurers;
    }
    public override void DoPower(List<CombatEntity> targets)
    {
        foreach(CombatEntity target in targets)
        {
            target.HealDamage(Effect);
        }
    }
}

public class BuffPower : PowerAction
{
    public BuffPower()
    {
        powerTarget = PowerTarget.Adventurers;
    }
    public override void DoPower(List<CombatEntity> targets)
    {
        foreach (CombatEntity target in targets)
        {
            target.BuffDamage(Effect);
        }
    }

}

public class DebuffPower : PowerAction
{
    public DebuffPower()
    {
        powerTarget = PowerTarget.Enemies;
    }
    public override void DoPower(List<CombatEntity> targets)
    {
        foreach (CombatEntity target in targets)
        {
            target.DebuffDamage(Effect);
        }
    }
}
