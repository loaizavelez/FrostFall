using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float randomX;

    void Update()
    {
        // Mover el obstáculo hacia abajo con la pista
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        // Destruir cuando salga de la cámara
        float camTop = Camera.main.transform.position.y + Camera.main.orthographicSize;
        Vector3 spawnPos = new Vector3(randomX, camTop - 1f, 0f);
        if (transform.position.y > camTop + 2f) 
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó obstáculo: " + gameObject.name);
            // Aquí aplicas daño, ralentización, etc.
        }
    }

}
