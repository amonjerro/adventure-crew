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

            //make sure capsule collider is in the same radius
            //so that two opponents both with 1 range can still fight with each other
            if(enemyEntity.TryGetComponent<CapsuleCollider>(out CapsuleCollider capsule))
            {
                //radius always 0.45 in world space
                //I just chose fs.scale.y as my factor
                capsule.radius = 0.45f / fs.scale.y;
            }
        }
    }

    public void Awake()
    {
        SpawnEnemies(CombatData.activeEnemyFormation);
    }
}