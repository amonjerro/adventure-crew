using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : UIMenu
{
    Dictionary<ICharacter, GameObject> wanderingDudes;

    public GameObject enemyPrefab;
    public GameObject adventurerPrefab;
    public GameObject playingField;
    public GameObject battleFavorBar;
    Material battleFavorBarMaterial;
    public Battle b;


    private void Start()
    {
        battleFavorBarMaterial = battleFavorBar.GetComponent<Image>().material;
        wanderingDudes = new Dictionary<ICharacter, GameObject>();
    }

    private void OnEnable()
    {
        // Instantiate all participants
        List<Adventurer> adventurers = b.GetAdventurers();
        for (int i = 0; i < adventurers.Count; i++)
        {
            GameObject ally = Instantiate(adventurerPrefab, adventurers[i].GetStats().Position, Quaternion.identity);
            wanderingDudes.Add(adventurers[i], ally);
        }

        List<Enemy> enemies = b.GetEnemies();

        for (int i = 0; i < enemies.Count; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemies[i].GetStats().Position, Quaternion.identity);
            wanderingDudes.Add(enemies[i], enemy);
        }
    }

    public void RenderBattleStatus()
    {
        // Update the favor bar
        battleFavorBarMaterial.SetFloat("_AllyVictoryPercentage", b.GetSquadHP() / (float)(b.GetEnemyHP() + b.GetSquadHP()));
        List<ICharacter> participants = b.GetParticipants();
        foreach(ICharacter participant in participants)
        {
            // Remove dead characters
            if (!participant.isAlive())
            {
                GameObject deadBoi = wanderingDudes[participant];
                Destroy(deadBoi);
                wanderingDudes.Remove(participant);
            } else
            {
                GameObject dude = wanderingDudes[participant];
                dude.transform.position = participant.GetStats().Position;
            }
        }


    }

    public void Dismiss()
    {
        foreach(KeyValuePair<ICharacter, GameObject> go in wanderingDudes)
        {
            Destroy(go.Value);
        }
        wanderingDudes.Clear();

        gameObject.SetActive(false);
    }

}