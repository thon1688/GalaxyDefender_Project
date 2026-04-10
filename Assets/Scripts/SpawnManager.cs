using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroidPrefab;
    private float spawnZ = 12.0f;
    private float spawnXRange = 10.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        // Start spawning asteroids repeatedly
        InvokeRepeating("SpawnAsteroid", startDelay, spawnInterval);
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnXRange, spawnXRange), 0.5f, spawnZ);
        Instantiate(asteroidPrefab, spawnPos, asteroidPrefab.transform.rotation);
    }
}