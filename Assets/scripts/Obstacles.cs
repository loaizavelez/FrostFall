using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float scrollSpeed = 2f;


    void Update()
    {
        // Mover el obstáculo hacia abajo con la pista
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        // Destruir cuando salga de la cámara
        float camBottom = Camera.main.transform.position.y - Camera.main.orthographicSize;
        if (transform.position.y < camBottom - 2f)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó el obstáculo: " + gameObject.name);
        }
    }
}
