using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ColorPalette colorPalette; // Referencia al ScriptableObject con los colores
    [SerializeField] private GameObject color1;
    [SerializeField] private GameObject color2;
    [SerializeField] private GameObject color3; // Objetos que contienen SpriteRenderer
    [SerializeField] private GameObject background; // Objeto de fondo

    private SpriteRenderer backgroundSpriteRenderer;
    private float raycastDistance = 100f; // Distancia del raycast para visualizarlo
    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;
    private SpriteRenderer spriteRenderer3;

    private void Start()
    {
        // Obtener los componentes SpriteRenderer de los GameObjects
        spriteRenderer1 = color1.GetComponent<SpriteRenderer>();
        spriteRenderer2 = color2.GetComponent<SpriteRenderer>();
        spriteRenderer3 = color3.GetComponent<SpriteRenderer>();

        // Asignar colores iniciales desde el ScriptableObject
        AssignRandomColor(spriteRenderer1);
        AssignRandomColor(spriteRenderer2);
        AssignRandomColor(spriteRenderer3);

        // Obtener el SpriteRenderer del fondo
        backgroundSpriteRenderer = background.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Dibujar el raycast en la escena
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red, 2f); 

            
            if (hit.collider != null)
            {
                Debug.Log($"Clic en objeto: {hit.collider.name}");

                
                if (hit.collider.CompareTag("paleta"))
                {
                    SpriteRenderer hitSpriteRenderer = hit.collider.GetComponent<SpriteRenderer>();

                    if (hitSpriteRenderer != null)
                    {
                       
                        backgroundSpriteRenderer.color = hitSpriteRenderer.color;

                        AssignRandomColor(hitSpriteRenderer);
                    }
                }
            }
            else
            {
                Debug.Log("No se ha golpeado ningún objeto.");
            }
        }
    }

    // Método para asignar un color aleatorio del ScriptableObject al SpriteRenderer
    private void AssignRandomColor(SpriteRenderer spriteRenderer)
    {
        int randomIndex = Random.Range(0, colorPalette.Colors.Length);
        spriteRenderer.color = colorPalette.Colors[randomIndex];
    }
}
