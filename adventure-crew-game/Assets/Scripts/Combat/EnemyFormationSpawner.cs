using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void SpawnEnemies(EnemyFormation formation)
    {
       foreach(FormationStruct fs in formation.formation)
        {
            GameObject enemyEntity = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyEntity.transform.SetParent(transform);
            CombatEntityEnemy enemyEntityComponent = enemyEntity.GetComponent<CombatEntityEnemy>();
            enemyEntityComponent.SetStats(fs.enemy);
            enemyEntity.transform.localPosition = fs.position;
            enemyEntity.transform.localScale = fs.scale;
        }
    }

    public void Awake()
    {
        SpawnEnemies(CombatData.activeEnemyFormation);
    }
}