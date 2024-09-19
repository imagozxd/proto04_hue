using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Wall"))
        {
            ObjectPoolCoins objectPoolCoins = FindObjectOfType<ObjectPoolCoins>();

            if (objectPoolCoins != null)
            {
                objectPoolCoins.ReturnCoin(gameObject);
            }
            else
            {
                Debug.LogError("ObjectPoolCoins no encontrado en la escena.");
            }
        }
    }
}
