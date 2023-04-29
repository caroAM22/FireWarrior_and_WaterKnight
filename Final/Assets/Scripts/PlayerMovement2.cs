using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; // Velocidad de movimiento
    [SerializeField] private float jumpForce = 10f; // Fuerza del salto
    [SerializeField] private float groundCheckRadius = 0.2f; // Radio del c�rculo para comprobar si est� en el suelo
    [SerializeField] private LayerMask whatIsGround; // Capa que representa el suelo

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Comprobar si est� en el suelo
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, whatIsGround);

        // Mover el personaje horizontalmente
        horizontalMovement = Input.GetAxisRaw("Horizontal2") * movementSpeed;

        // Saltar si est� en el suelo y se pulsa la tecla W
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Aplicar la velocidad de movimiento horizontal al Rigidbody del personaje
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }
}
