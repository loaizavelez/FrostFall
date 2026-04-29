using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speedX = 5f;
    public float tiempoInvulnerable = 1.5f;
    public bool esInvulnerable = false;

    private Rigidbody2D rb;
    private float moveX;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveX * speedX + rb.linearVelocity.x * 0.9f, 0f);
    }

    public void ActivarInvulnerabilidad()
    {
        if (!esInvulnerable)
        {
            StartCoroutine(InvulnerabilidadCoroutine());
        }
    }

    private IEnumerator InvulnerabilidadCoroutine()
    {
        esInvulnerable = true;

        // Efecto visual de parpadeo
        float tiempoPasado = 0;
        while (tiempoPasado < tiempoInvulnerable)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
            tiempoPasado += 0.1f;
        }

        sprite.enabled = true;
        esInvulnerable = false;
    }
}