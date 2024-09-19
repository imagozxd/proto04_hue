using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2f; // Tasa de aparición de monedas
    [SerializeField] private Vector2 spawnArea; // Área de aparición de monedas

    private void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnRate);
    }

    private void SpawnCoin()
    {
        GameObject coin = ObjectPoolCoins.Instance.GetCoin();

        // Configurar la posición de la moneda
        float xPos = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
        float yPos = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);
        coin.transform.position = new Vector2(xPos, yPos);

        // Configurar cualquier otra propiedad de la moneda si es necesario
    }
}
