using UnityEngine;

public class PlayerHUE : MonoBehaviour
{
    [SerializeField] private float speed = 5f;       // Velocidad del movimiento horizontal
    [SerializeField] private float jumpForce = 7f;   // Fuerza del salto
    [SerializeField] private LayerMask groundLayer;  // Capa del suelo para el Raycast
    [SerializeField] private Transform groundCheck;  // Posici�n desde donde lanzar el Raycast para detectar el suelo
    [SerializeField] private float groundCheckDistance = 0.1f;  // Distancia del Raycast para verificar el suelo
    [SerializeField] private int vida = 3;           // Vida del jugador

    private Rigidbody2D rb;
    private int jumpCount = 0;        // N�mero de saltos realizados
    private bool isGrounded = false;  // Indica si el jugador est� en el suelo


    [SerializeField] private LifeEvent lifeEvent;
    public int Vida
    {
        get { return vida; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeEvent.Raise(vida);
    }

    private void Update()
    {
        Move();
        Jump();

        
        //if (isGrounded && rb.velocity.y < -10f)
        //{
        //    TakeDamage(1);  // Llama a la nueva funci�n para reducir vida
        //}
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

    // Nueva funci�n para reducir la vida del jugador
    public void TakeDamage(int amount)
    {
        vida -= amount;
        Debug.Log("Vida del jugador: " + vida);
        lifeEvent.Raise(vida);

        if (vida <= 0)
        {
            Debug.Log("El jugador ha muerto.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
}
