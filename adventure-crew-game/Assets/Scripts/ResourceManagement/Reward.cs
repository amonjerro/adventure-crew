public struct Reward
{
    public int gold;
    public int xp;

    public Reward(int gld)
    {
        gold = gld;
        xp = 0;
    }

    public void SetXPReward(int v)
    {
        xp = v;
    }
}