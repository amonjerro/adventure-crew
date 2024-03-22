public struct Stats
{
    public int HP { get; set; }
    public int Damage { get; private set; }
    public int Agility { get; private set; }
    public float Range { get; private set; }

    // General Constructor
    public Stats(int hp, int damage, int agility)
    {
        HP = hp;
        Damage = damage;
        Agility = agility;
        Range = 1.0f;
    }

    // Constructor for ranged units
    public Stats(int hp, int damage, int agility, float rng)
    {
        HP = hp;
        Damage = damage;
        Agility = agility;
        Range = rng;
    }
}