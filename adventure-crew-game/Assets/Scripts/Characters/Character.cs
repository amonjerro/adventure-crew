public interface ICharacter
{
    public Stats GetStats();
    public void Die();

    public void SetStrategy(ICombatStrategy strategy);

    public void GetNextAction();
}