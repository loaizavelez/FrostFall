using UnityEngine;

public class BackGround : MonoBehaviour
{
   
    private float baseSpeed = 2f;    // Velocidad a la que se mueve el fondo
    private float tileSizeY = 10.07f;   // Tamaño del fondo en el eje Y (ajusta según tu sprite)
    private float acceleration = 0.2f; // Aceleración para aumentar la velocidad con el tiempo  
    private float scrollSpeed; // Velocidad actual del scroll, que se actualizará con la aceleración
    private Vector3 startPos; // Posición inicial del fondo
    float distance; // Distancia recorrida para el scroll
    float newPos; // Nueva posición calculada para el scroll

    void Start()
    {
        startPos = transform.position; // Guardamos la posición inicial del fondo
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float width = sr.bounds.size.x;
        float height = sr.bounds.size.y;
        Debug.Log("Ancho del fondo: " + width + " | Alto del fondo: " + height);
    }

    // Update is called once per frame
    void Update()
    {

        scrollSpeed = baseSpeed + (Time.time * acceleration); // Aumentamos la velocidad de desplazamiento con el tiempo usando la aceleración

        Debug.Log("Velocidad actual del fondo: " + scrollSpeed);


        distance = Time.time * scrollSpeed; // Calculamos la distancia recorrida multiplicando el tiempo por la velocidad
        newPos = distance % tileSizeY; // reinicio manual con módulo
        transform.position = startPos + Vector3.up * newPos; // Movemos el fondo hacia arriba sumando la nueva posición calculada a la posición inicial
    }
}
