using UnityEngine;

public class TrackManager : MonoBehaviour
{
    private float baseSpeed = 2f;              // Velocidad inicial
    private float acceleration = 0.2f;         // Aceleración por segundo
    private float tileSizeY = 10.07f;          // Tamaño del fondo en Y
    private float scrollSpeed;
    private float distanciaAcumulada = 0f;
    private float tiempoAnterior = 0f;
    private Vector3 startPos;

    private bool scrollDetenido = false;
    private float intervaloPausa = 150f;        // Cada 15 unidades se detiene
    private float siguientePausa = 150f;        // Próxima distancia de pausa

    void Start()
    {
        startPos = transform.position;
        tiempoAnterior = Time.time;
    }

    void Update()
    {
        // Si está detenido, espera tecla C
        if (scrollDetenido)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                scrollDetenido = false;
                tiempoAnterior = Time.time;
                siguientePausa += intervaloPausa; // programar la siguiente pausa
                Debug.Log("Scroll reanudado con tecla C");
            }
            return;
        }

        // Calcular delta de tiempo
        float deltaTime = Time.time - tiempoAnterior;
        tiempoAnterior = Time.time;

        // Velocidad lineal con el tiempo
        scrollSpeed = baseSpeed + (Time.timeSinceLevelLoad * acceleration);

        // Acumular distancia recorrida
        distanciaAcumulada += scrollSpeed * deltaTime;

        // Nueva posición del fondo principal
        float newPos = distanciaAcumulada % tileSizeY;
        transform.position = startPos + Vector3.up * newPos;

        Debug.Log("Velocidad: " + scrollSpeed + " | Distancia actual: " + distanciaAcumulada);

        // Pausa automática cada intervalo
        if (distanciaAcumulada >= siguientePausa)
        {
            scrollDetenido = true;
            Debug.Log("Pausa automática en distancia: " + siguientePausa + ". Pulsa C para continuar...");
        }
    }
}
