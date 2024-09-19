using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolCoins : MonoBehaviour
{
    public static ObjectPoolCoins Instance; // Instancia del pool
    [SerializeField] private GameObject coinPrefab; // Prefab de moneda
    [SerializeField] private int poolSize = 10; // Tamaño inicial del pool

    private Queue<GameObject> coinPool; // Cola para gestionar las monedas

    private void Awake()
    {
        // Implementar el patrón Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePool();
    }

    private void InitializePool()
    {
        coinPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            coinPool.Enqueue(coin);
        }
    }

    public GameObject GetCoin()
    {
        if (coinPool.Count > 0)
        {
            GameObject coin = coinPool.Dequeue();
            coin.SetActive(true);
            return coin;
        }
        else
        {
            GameObject coin = Instantiate(coinPrefab);
            return coin;
        }
    }

    public void ReturnCoin(GameObject coin)
    {
        coin.SetActive(false);
        coinPool.Enqueue(coin);
    }
}
