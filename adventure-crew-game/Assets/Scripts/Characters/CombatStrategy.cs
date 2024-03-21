public interface ICombatStrategy
{
    public void FindTarget();
    public void OnTargetFind();
    public void Attack(int damage);
    public void Move(int agility);
    public void DecideNextAction(Stats stats);

}
