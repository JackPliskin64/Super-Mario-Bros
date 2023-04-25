using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 10f; // velocidad del personaje
    public float jumpForce = 700f; // fuerza del salto
    public Transform groundCheck; // transformador para verificar si el personaje está en el suelo
    public LayerMask whatIsGround; // capa para definir qué es considerado suelo
    public float minScreenX; // límite izquierdo de la pantalla
    private bool isGrounded; // verifica si el personaje está en el suelo
    private Rigidbody2D rb; // componente Rigidbody2D del personaje
    public CameraFollow cameraScript;
    public float limitOffset;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtener componente Rigidbody2D
    }

    private void FixedUpdate()
    {

        minScreenX = cameraScript.minX - limitOffset;

        // verificar si el personaje está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

        // mover el personaje
        float move = Input.GetAxis("Horizontal");

        // asegurarse de que el personaje no se mueva más allá del límite izquierdo de la pantalla
        if (transform.position.x < minScreenX && move < 0)
        {
            move = 0f;
        }

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // voltear el sprite del personaje si es necesario
        if (move < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (move > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void Update()
    {
        // permitir saltar si el personaje está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
