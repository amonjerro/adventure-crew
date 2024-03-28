using System.Collections.Generic;

public class Battle
{
    List<ICharacter> participants;
    private List<Adventurer> adventurers;
    private List<Enemy> enemies;
    private int remainingEnemyHP;
    private int remainingPlayerHP;

    public Battle()
    {
        participants = new List<ICharacter>();
        adventurers = new List<Adventurer>();
        enemies = new List<Enemy>();
        remainingPlayerHP = 0;
        remainingEnemyHP = 0;
    }

    public void ProcessTick()
    {
        // If combat has yet to be resolved, proceed with battle
        if (remainingEnemyHP > 0 && remainingPlayerHP > 0)
        {
            foreach (ICharacter participant in participants)
            {
                participant.GetNextAction();
            }
        }

        remainingPlayerHP = UpdatePlayerHp();
        remainingEnemyHP = UpdateEnemyHp();
    }

    public void Setup(List<ICharacter> adventurers, List<ICharacter> enemies)
    {
        int totalCount = adventurers.Count >= enemies.Count ? adventurers.Count : enemies.Count;
        for (int i = 0; i < totalCount; i++)
        {
            if (i < adventurers.Count)
            {
                adventurers.Add((Adventurer)adventurers[i]);
                participants.Add(adventurers[i]);
                remainingPlayerHP += adventurers[i].GetStats().MaxHP;
                adventurers[i].Initiative = UnityEngine.Random.Range(1, 20);
            }

            if (i < enemies.Count)
            {
                enemies.Add((Enemy)enemies[i]);
                participants.Add(enemies[i]);
                remainingPlayerHP += enemies[i].GetStats().MaxHP;
                enemies[i].Initiative = UnityEngine.Random.Range(1, 20);
            }
        }
        // Sort by initiative
        participants.Sort();
    }

    public int GetSquadHP()
    {
        return remainingPlayerHP;
    }

    public int GetEnemyHP()
    {
        return remainingEnemyHP;
    }

    private int UpdatePlayerHp()
    {
        int output = 0;
        foreach(Adventurer adv in adventurers)
        {
            output += adv.GetStats().HP;
        }
        return output;
    }

    private int UpdateEnemyHp()
    {
        int output = 0;
        foreach (Enemy e in enemies)
        {
            output += e.GetStats().HP;
        }
        return output;
    }


}