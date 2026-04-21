using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedX = 5f;   // velocidad lateral
    private Rigidbody2D rb;
    private float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal"); // teclas A/D o flechas
        rb.linearVelocity = new Vector2(moveX * speedX, 0f);

       
    }
}
