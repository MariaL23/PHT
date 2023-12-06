using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSpawner : MonoBehaviour
{
    public GameObject cupPrefab; // Reference to the cup prefab to spawn
    public Transform spawnPoint; // Point where the cup will be spawned

    public int spawnDelay = 5; // Delay in seconds before spawning a new cupS

    private bool isInside = false; // Flag to track whether an object is inside the collider

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the specified tag (e.g., "Cup")
        if (other.CompareTag("CUP"))
        {
            isInside = true;
           // Debug.Log("Cup is inside the collider.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the specified tag (e.g., "Cup")
        if (other.CompareTag("CUP"))
        {
            isInside = false;
           // Debug.Log("Cup has exited the collider.");
        }
    }

    private void Update()
    {
        // Check if a cup needs to be spawned
        if (!isInside)
        {
            StartCoroutine(SpawnCup());
           
            isInside = true; // Set to true to avoid continuous spawning
        }
    }

    private IEnumerator SpawnCup()
    {
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
    }
}
