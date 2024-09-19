using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private EnemyPool enemyPool; // Referencia al pool de enemigos

    private void Start()
    {
        // Obtener la referencia al pool de enemigos
        enemyPool = FindObjectOfType<EnemyPool>();

        if (enemyPool == null)
        {
            Debug.LogError("No se encontr� EnemyPool en la escena.");
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aqu� puedes restar 1 de vida al jugador o realizar cualquier otra acci�n necesaria
            Debug.Log("Enemigo impact� al jugador");

            // Devolver el enemigo al pool
            if (enemyPool != null)
            {
                enemyPool.ReturnEnemy(gameObject);
            }
        }
        else if (other.CompareTag("Wall"))
        {
            // El enemigo se destruye y se devuelve al pool
            Debug.Log("Enemigo impact� una pared");

            if (enemyPool != null)
            {
                enemyPool.ReturnEnemy(gameObject);
            }
        }
    }
}
