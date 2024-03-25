public interface IResource
{
    public void Spend(int value);
    public void Add(int value);
    public bool CanSpend(int value);

    public int GetAmount();

}

public class Gold : IResource
{
    int amount;
    public void Spend(int value)
    {
        amount -= value;
    }

    public int GetAmount()
    {
        return amount;
    }

    public void Add(int value)
    {
        amount += value;
    }

    public void Add(Gold other)
    {
        amount += other.GetAmount();
    }

    public bool CanSpend(int value)
    {
        return amount >= value;
    }
}
