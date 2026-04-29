using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnXRange = 3f;
    public float spawnY = 6f;
    public float spawnRate = 1f;

    void Start()
    {
        InvokeRepeating("SpawnCoin", 1f, spawnRate);
        Destroy(gameObject, 10f);
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0);

        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}