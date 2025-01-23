using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject[] trapPrefabs; // Array to hold different trap prefabs
    public float initialSpawnInterval = 2f; // Initial time between each trap spawn
    public float minSpawnInterval = 0.5f;   // Minimum time between spawns
    public float spawnX = 10f;              // X position to spawn traps
    public float minY = -3f;                // Minimum Y position for trap spawning
    public float maxY = 3f;                 // Maximum Y position for trap spawning
    public float difficultyCurve = 0.01f;  // Controls how fast the interval decreases over time

    private float currentSpawnInterval;
    private float elapsedTime = 0f;

    private void Start()
    {
        // Set the initial spawn interval
        currentSpawnInterval = initialSpawnInterval;

        // Start spawning traps
        Invoke(nameof(SpawnTrap), currentSpawnInterval);
    }

    private void SpawnTrap()
    {
        // Randomly select a trap prefab
        GameObject randomTrap = trapPrefabs[Random.Range(0, trapPrefabs.Length)];

        // Randomize the Y position within the range
        float randomY = Random.Range(minY, maxY);

        // Instantiate the trap at the spawn position
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);
        Instantiate(randomTrap, spawnPosition, Quaternion.identity);

        // Update elapsed time
        elapsedTime += currentSpawnInterval;

        // Gradually decrease the spawn interval using a non-linear function
        currentSpawnInterval = Mathf.Max(minSpawnInterval, initialSpawnInterval / (1f + difficultyCurve * elapsedTime));

        // Schedule the next spawn
        Invoke(nameof(SpawnTrap), currentSpawnInterval);
    }
}
