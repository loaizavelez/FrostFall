using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [Header("Scroll")]
    public float baseSpeed = 2f;              // Velocidad inicial
    public float acceleration = 0.2f;         // Aceleración por segundo
    public float tileSizeY = 10.07f;          // Tamaño del fondo en Y
    private float scrollSpeed;
    private float distanciaAcumulada = 0f;
    private float tiempoAnterior = 0f;
    private Vector3 startPos;

    private bool scrollDetenido = false;
    public float intervaloPausa = 15f;        // Cada 15 unidades se detiene
    private float siguientePausa = 15f;

    [Header("Obstáculos")]
    public GameObject piedraPrefab;
    public GameObject nievePrefab;
    public GameObject arbolPrefab;
    public float spawnInterval = 5f;          // Cada cuántas unidades se genera un obstáculo
    private float siguienteSpawn = 5f;

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
                siguientePausa += intervaloPausa;
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

        // Spawning de obstáculos
        if (distanciaAcumulada >= siguienteSpawn)
        {
            SpawnObstaculo();
            siguienteSpawn += spawnInterval;
        }
    }

    void SpawnObstaculo()
    {
        int tipo = Random.Range(0, 3); // 0 = piedra, 1 = nieve, 2 = árbol
        GameObject prefab = null;

        switch (tipo)
        {
            case 0: prefab = piedraPrefab; break;
            case 1: prefab = nievePrefab; break;
            case 2: prefab = arbolPrefab; break;
        }

        if (prefab != null)
        {
            // Ajustar al ancho real de la pista (10.07)
            float halfWidth = tileSizeY / 2f; // = 5.035
            float randomX = Random.Range(-halfWidth, halfWidth);

            // Borde superior de la cámara
            float camTop = Camera.main.transform.position.y + Camera.main.orthographicSize;

            Vector3 spawnPos = new Vector3(randomX, camTop + 1f, 0f);

            GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

            // Asignar velocidad al script Obstaculo
            Obstacles o = obj.GetComponent<Obstacles>();
            if (o != null)
            {
                o.scrollSpeed = scrollSpeed;
            }

            Debug.Log("Spawn de obstáculo: " + prefab.name + " en X=" + randomX + " | Y=" + spawnPos.y);
        }
    }
}
