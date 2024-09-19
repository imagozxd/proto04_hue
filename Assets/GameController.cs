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
        // Comprobar si se ha hecho clic en la pantalla
        if (Input.GetMouseButtonDown(0))
        {
            // Realizar un raycast desde la posición del ratón
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Dibujar el raycast en la escena
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red, 2f); // Color rojo y duración de 2 segundos

            // Verificar si el raycast ha golpeado algo
            if (hit.collider != null)
            {
                // Imprimir información sobre el objeto golpeado
                Debug.Log($"Clic en objeto: {hit.collider.name}");

                // Verificar si el objeto golpeado tiene el tag "paleta"
                if (hit.collider.CompareTag("paleta"))
                {
                    // Obtener el SpriteRenderer del objeto golpeado
                    SpriteRenderer hitSpriteRenderer = hit.collider.GetComponent<SpriteRenderer>();

                    if (hitSpriteRenderer != null)
                    {
                        // Asignar el color del SpriteRenderer golpeado al fondo
                        backgroundSpriteRenderer.color = hitSpriteRenderer.color;

                        // Cambiar el color de la paleta a un color aleatorio del arreglo
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
