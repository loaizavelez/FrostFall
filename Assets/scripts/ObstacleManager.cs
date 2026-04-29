using UnityEngine;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    [Header("Referencias")]
    public TrackManager trackManager;
    public GameObject[] obstaclePrefabs;

    [Header("Configuración de Cantidad")]
    public int poolSize = 10;

    [Header("Configuración de la Cinta")]
    public float spawnRangeX = 6f;
    public float resetThresholdY = 8f;
    public float spawnBottomY = -8f;
    public float minDistanceY = 3f;

    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        if (trackManager == null)
            trackManager = FindFirstObjectByType<TrackManager>();

        InicializarObstaculos();
    }

    void InicializarObstaculos()
    {
        foreach (GameObject obj in pool) Destroy(obj);
        pool.Clear();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
            float startY = spawnBottomY + (i * minDistanceY);
            obj.transform.position = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), startY, 0);
            pool.Add(obj);
        }
    }

    void Update()
    {
        if (trackManager != null && !trackManager.scrollDetenido)
        {
            MoverYReciclar();
        }
    }

    void MoverYReciclar()
    {
        float speed = trackManager.scrollSpeed;

        foreach (GameObject obstacle in pool)
        {
            if (!obstacle.activeSelf) continue;

            obstacle.transform.Translate(Vector3.up * speed * Time.deltaTime);

            if (obstacle.transform.position.y > resetThresholdY)
            {
                // Si el manager dice que estamos llegando al final, desactivamos en vez de reciclar
                if (trackManager.limpiandoObstaculos)
                {
                    obstacle.SetActive(false);
                }
                else
                {
                    Reciclar(obstacle);
                }
            }
        }
    }

    void Reciclar(GameObject obj)
    {
        float newX = Random.Range(-spawnRangeX, spawnRangeX);
        float newY = spawnBottomY - Random.Range(0f, 2f);
        obj.transform.position = new Vector3(newX, newY, 0);
    }
}