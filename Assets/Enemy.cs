using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private ColorPalette colorPalette;
    [SerializeField] private GameObject background;

    private EnemyPool enemyPool;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer backgroundRenderer;

    private void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();

        if (enemyPool == null)
        {
            Debug.LogError("No se encontró EnemyPool en la escena.");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer no encontrado en el GameObject.");
        }
        else
        {
            AssignRandomColor(spriteRenderer);
        }

        if (background != null)
        {
            backgroundRenderer = background.GetComponent<SpriteRenderer>();
            if (backgroundRenderer == null)
            {
                Debug.LogError("SpriteRenderer no encontrado en el GameObject de fondo.");
            }
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
            if (enemyPool != null)
            {
                enemyPool.ReturnEnemy(gameObject);
            }
        }
        else if (other.CompareTag("Wall"))
        {
            if (enemyPool != null)
            {
                enemyPool.ReturnEnemy(gameObject);
            }
        }
    }

    private void AssignRandomColor(SpriteRenderer spriteRenderer)
    {
        if (colorPalette != null && colorPalette.Colors.Length > 0)
        {
            int randomIndex = Random.Range(0, colorPalette.Colors.Length);
            spriteRenderer.color = colorPalette.Colors[randomIndex];

            if (backgroundRenderer != null)
            {
                if (spriteRenderer.color == backgroundRenderer.color)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Debug.LogWarning("ColorPalette no está asignado o está vacío.");
        }
    }
}
