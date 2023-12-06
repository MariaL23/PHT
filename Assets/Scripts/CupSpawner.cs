using System.Collections;
using UnityEngine;

public class CupSpawner : MonoBehaviour
{
    public GameObject cupPrefab; // Reference to the cup prefab to spawn
    public Transform spawnPoint; // Point where the cup will be spawned
    public int spawnDelay = 5; // Delay in seconds before spawning a new cup

    private bool isInside = false; // Flag to track whether an object is inside the collider
    private bool isSpawning = false; // Flag to track whether the SpawnCup coroutine is running

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the specified tag (e.g., "Cup")
        if (other.CompareTag("CUP"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the specified tag (e.g., "Cup")
        if (other.CompareTag("CUP"))
        {
            if (!isSpawning)
            {
                StartCoroutine(SpawnCup());
            }
        }
    }

    private IEnumerator SpawnCup()
    {
        isSpawning = true; // Set flag to true before spawning
        yield return new WaitForSeconds(spawnDelay);

        // Spawn a new cup at the specified spawn point
        if (cupPrefab != null && spawnPoint != null)
        {
            Instantiate(cupPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Cup spawned.");
        }
        else
        {
            Debug.LogError("Cup prefab or spawn point not assigned!");
        }

        isSpawning = false; // Reset flag after spawning
    }
}
