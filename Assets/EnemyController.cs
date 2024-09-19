using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float minSpawnRate = 5f;
    [SerializeField] private float maxSpawnRate = 10f;

    private EnemyPool enemyPool;

    private void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();

        if (enemyPool == null)
        {
            Debug.LogError("No se encontró EnemyPool en la escena.");
            return;
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPool != null)
        {
            GameObject enemy = enemyPool.GetEnemy();
            if (enemy != null)
            {
                enemy.transform.position = spawnPosition.position;
            }
        }
        else
        {
            Debug.LogWarning("EnemyPool no está disponible.");
        }
    }
}
