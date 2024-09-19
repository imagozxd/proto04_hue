using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // Prefab del enemigo
    [SerializeField] private int poolSize = 10;      // Tamaño del pool
    private List<GameObject> enemyPool;              // Lista que almacena los enemigos

    private void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab no está asignado en el Inspector.");
            return;
        }

        Debug.Log("Enemy Prefab asignado correctamente.");

        // Inicializar la lista de enemigos
        enemyPool = new List<GameObject>();

        // Crear y desactivar enemigos según el tamaño del pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    // Método para obtener un enemigo inactivo del pool
    public GameObject GetEnemy()
    {
        if (enemyPool == null || enemyPool.Count == 0)
        {
            Debug.LogError("Enemy pool no está inicializado o está vacío.");
            return null;
        }

        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        // Si no hay enemigos disponibles, expandir el pool
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(true);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }

    // Método para devolver un enemigo al pool
    public void ReturnEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Intento de devolver un enemigo al pool que es null.");
        }
    }
}
