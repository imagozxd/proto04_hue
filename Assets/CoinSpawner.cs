using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2f; // Tasa de aparición (en segundos) entre oleadas
    [SerializeField] private int coinsPerWave = 5; // Cantidad de monedas por oleada
    [SerializeField] private Vector2 spawnArea; // Área de aparición de monedas
    [SerializeField] private Transform spawnTransform; // Posición central para la aparición (se asigna en el inspector)
    [SerializeField] private ObjectPoolCoins objectPoolCoins; // Referencia al pool de monedas

    private void Start()
    {
        if (objectPoolCoins == null)
        {
            Debug.LogError("ObjectPoolCoins no está asignado en el Inspector.");
            return;
        }

        // Iniciar la corutina de aparición de monedas
        StartCoroutine(SpawnCoinsContinuously());
    }

    // Corutina para instanciar monedas continuamente
    private IEnumerator SpawnCoinsContinuously()
    {
        while (true) // Para que siga ejecutándose indefinidamente
        {
            // Instanciar un número determinado de monedas por cada oleada
            for (int i = 0; i < coinsPerWave; i++)
            {
                SpawnCoin();
            }

            // Esperar antes de la siguiente oleada
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Método para instanciar una moneda
    private void SpawnCoin()
    {
        if (objectPoolCoins != null)
        {
            GameObject coin = objectPoolCoins.GetCoin();

            // Configurar la posición de la moneda dentro del área
            float xPos = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
            float yPos = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);
            Vector2 spawnPosition = new Vector2(xPos, yPos) + (Vector2)spawnTransform.position; // Ajustar con respecto al transform

            coin.transform.position = spawnPosition;

            // Cualquier otra configuración adicional de la moneda si es necesario
        }
        else
        {
            Debug.LogError("ObjectPoolCoins no está asignado.");
        }
    }
}
