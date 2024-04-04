using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void SpawnEnemies(EnemyFormation formation)
    {
       foreach(FormationStruct fs in formation.formation)
        {
            Quaternion rotation = Quaternion.AngleAxis(fs.rotation.y, Vector3.up);
            GameObject enemyEntity = Instantiate(enemyPrefab, transform.position, rotation);
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