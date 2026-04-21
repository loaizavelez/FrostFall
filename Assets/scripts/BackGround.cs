using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float baseSpeed = 2f;
    private float acceleration = 0.2f;
    private float tileSizeY = 10.07f;
    private float scrollSpeed;
    private float distanciaAcumulada = 0f;
    private float tiempoAnterior = 0f;
    private Vector3 startPos;

    [System.Serializable]
    public class Tramo
    {
        public float distancia;       // distancia en la que se congela
        public GameObject fondo;      // fondo que aparece en ese tramo
        [HideInInspector] public bool activado = false;
    }

    public Tramo[] tramos; // lista de tramos configurables en el inspector
    private bool scrollDetenido = false;

    void Start()
    {
        startPos = transform.position;
        tiempoAnterior = Time.time;

        // desactivar todos los fondos al inicio
        foreach (var t in tramos)
        {
            if (t.fondo != null) t.fondo.SetActive(false);
        }
    }

    void Update()
    {
        if (scrollDetenido)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                scrollDetenido = false;
                tiempoAnterior = Time.time;
                Debug.Log("Scroll reanudado con tecla C");
            }
            return;
        }

        float deltaTime = Time.time - tiempoAnterior;
        tiempoAnterior = Time.time;

        scrollSpeed = baseSpeed + (distanciaAcumulada * acceleration);
        distanciaAcumulada += scrollSpeed * deltaTime;

        float newPos = distanciaAcumulada % tileSizeY;
        transform.position = startPos + Vector3.up * newPos;

        Debug.Log("Velocidad: " + scrollSpeed + " | Distancia actual: " + distanciaAcumulada);

        // revisar cada tramo
        foreach (var t in tramos)
        {
            if (!t.activado && distanciaAcumulada >= t.distancia)
            {
                t.activado = true;
                scrollDetenido = true; // congelar scroll

                if (t.fondo != null)
                {
                    t.fondo.SetActive(true);
                    t.fondo.transform.position = transform.position;
                }

                Debug.Log("Fin de tramo en distancia: " + t.distancia + ". Pulsa C para continuar...");
                break; // salir del foreach para no activar varios a la vez
            }
        }
    }
}
