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
            Debug.LogError("No se encontró EnemyPool en la escena.");
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
            // Aquí puedes restar 1 de vida al jugador o realizar cualquier otra acción necesaria
            Debug.Log("Enemigo impactó al jugador");

            // Devolver el enemigo al pool
            if (enemyPool != null)
            {
                enemyPool.ReturnEnemy(gameObject);
            }
        }
        else if (other.CompareTag("Wall"))
        {
            // El enemigo se destruye y se devuelve al pool
            Debug.Log("Enemigo impactó una pared");

            if (enemyPool != null)
            {
                enemyPool.ReturnEnemy(gameObject);
            }
        }
    }
}
