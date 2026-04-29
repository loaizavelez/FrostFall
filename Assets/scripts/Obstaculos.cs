using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public float fuerzaEmpuje = 5f;
    public float reduccionAceleracion = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null && !player.esInvulnerable)
            {
                float direccion = other.transform.position.x > transform.position.x ? 1f : -1f;

                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                    rb.AddForce(new Vector2(direccion * fuerzaEmpuje, 0), ForceMode2D.Impulse);
                }

                player.ActivarInvulnerabilidad();

                TrackManager track = FindFirstObjectByType<TrackManager>();
                if (track != null)
                {
                    track.acceleration = Mathf.Max(0, track.acceleration - reduccionAceleracion);
                    track.scrollSpeed *= 0.5f;
                }
            }
        }
    }
}