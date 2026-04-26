using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Configuración de movimiento
    public float speedX = 5f;   // velocidad lateral
    private Rigidbody2D rb;
    private float moveX;
    private SpriteRenderer spriteRenderer;

    // Variables para limitar movimiento dentro de la cámara
    private float halfWidth;
    private float camLeft;
    private float camRight;


    // Variable temporal para ajustar posición
    private Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speedX, rb.velocity.y);

        // Flip del sprite según dirección
        if (moveX < 0)
            spriteRenderer.flipX = false; // mirando a la derecha
        else if (moveX > 0)
            spriteRenderer.flipX = true;  // mirando a la izquierda
        halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        camLeft = Camera.main.transform.position.x - halfWidth;
        camRight = Camera.main.transform.position.x + halfWidth;


        // Limitar posición del jugador dentro de la cámara
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, camLeft + 0.5f, camRight - 0.5f);
        transform.position = pos;

    }
}
