using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackManager : MonoBehaviour
{
    [Header("Configuración de la Tienda")]
    public string shopSceneName = "Tienda";
    public float baseSpeed = 2f;
    public float acceleration = 0.2f;
    public float tileSizeY = 10.07f;
    public float scrollSpeed;
    public bool scrollDetenido = false;

    [Header("Configuración de Meta")]
    public float distanciaParaMeta = 500f;
    public float distanciaAvisoFinal = 50f;
    public bool limpiandoObstaculos = false;

    private float distanciaAcumulada = 0f;
    private float tiempoAnterior = 0f;
    private Vector3 startPos;
    private float intervaloPausa = 150f;
    private float siguientePausa = 150f;

    void Start()
    {
        startPos = transform.position;
        tiempoAnterior = Time.time;
    }

    void Update()
    {
        if (scrollDetenido)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                scrollDetenido = false;
                tiempoAnterior = Time.time;
                siguientePausa += intervaloPausa;
            }
            return;
        }

        float deltaTime = Time.time - tiempoAnterior;
        tiempoAnterior = Time.time;

        scrollSpeed = baseSpeed + (Time.timeSinceLevelLoad * acceleration);
        distanciaAcumulada += scrollSpeed * deltaTime;

        float newPos = distanciaAcumulada % tileSizeY;
        transform.position = startPos + Vector3.up * newPos;

        // Verificar si estamos cerca del final para dejar de spawnear
        if (distanciaAcumulada >= (distanciaParaMeta - distanciaAvisoFinal)) 
        {
            limpiandoObstaculos = true;
        }

        if (distanciaAcumulada >= siguientePausa)
        {
            scrollDetenido = true;
            SceneManager.LoadScene(shopSceneName);
        }
    }
}