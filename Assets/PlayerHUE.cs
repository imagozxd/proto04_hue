using UnityEngine;

public class PlayerHUE : MonoBehaviour
{
    [SerializeField] private float speed = 5f;       // Velocidad del movimiento horizontal
    [SerializeField] private float jumpForce = 7f;   // Fuerza del salto
    [SerializeField] private LayerMask groundLayer;  // Capa del suelo para el Raycast
    [SerializeField] private Transform groundCheck;  // Posición desde donde lanzar el Raycast para detectar el suelo
    [SerializeField] private float groundCheckDistance = 0.1f;  // Distancia del Raycast para verificar el suelo
    [SerializeField] private int vida = 3;           // Vida del jugador

    private Rigidbody2D rb;
    private int jumpCount = 0;        // Número de saltos realizados
    private bool isGrounded = false;  // Indica si el jugador está en el suelo

    public int Vida
    {
        get { return vida; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();

        // Ejemplo: Reducir vida si el jugador toca el suelo con fuerza (puedes cambiar esta lógica)
        if (isGrounded && rb.velocity.y < -10f)
        {
            vida--;
            Debug.Log("Vida del jugador: " + vida);
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void Jump()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpCount < 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplicar la fuerza de salto
                jumpCount++;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
}
