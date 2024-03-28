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
                if (participant.isAlive())
                {
                    participant.GetNextAction();
                }
            }
        }

        remainingPlayerHP = UpdatePlayerHp();
        remainingEnemyHP = UpdateEnemyHp();
    }


    public void Setup(List<ICharacter> formationAdventurers, List<ICharacter> formationEnemies)
    {
        // Clear internal lists
        participants.Clear();
        adventurers.Clear();
        enemies.Clear();

        int totalCount = formationAdventurers.Count >= formationEnemies.Count ? formationAdventurers.Count : formationEnemies.Count;
        for (int i = 0; i < totalCount; i++)
        {
            if (i < adventurers.Count)
            {
                adventurers.Add((Adventurer)formationAdventurers[i]);
                participants.Add(adventurers[i]);
                remainingPlayerHP += adventurers[i].GetStats().MaxHP;
                adventurers[i].Initiative = UnityEngine.Random.Range(1, 20);
            }

            if (i < enemies.Count)
            {
                enemies.Add((Enemy)formationEnemies[i]);
                participants.Add(enemies[i]);
                remainingPlayerHP += enemies[i].GetStats().MaxHP;
                enemies[i].Initiative = UnityEngine.Random.Range(1, 20);
            }
        }
        // Sort by initiative
        participants.Sort();
    }

    public List<Adventurer> GetAdventurers()
    {
        return adventurers;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    public List<ICharacter> GetParticipants()
    {
        return participants;
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