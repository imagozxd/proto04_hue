using UnityEngine;
using UnityEngine.Pool;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes agregar lógica para sumar puntos, efectos, etc.

            // Devolver la moneda al pool
            ObjectPoolCoins.Instance.ReturnCoin(gameObject);
        }
    }
}
