using System.Collections;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject[] npcPrefabs;  // Array of NPC prefabs to choose from
    public Transform spawnPoint;     // Point where NPCs will be spawned
    public float spawnInterval = 240f;  // Time between NPC spawns in seconds (4 minutes)
    
      private int currentPrefabIndex = 0; 
    private void Start()
    {
        SpawnInitialNPC();
        // Start spawning NPCs at regular intervals
        StartCoroutine(SpawnNPCs());
    }

    IEnumerator SpawnNPCs()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Choose a random NPC prefab from the array
            GameObject selectedPrefab = npcPrefabs[currentPrefabIndex];

            // Spawn the selected NPC at the spawn point
            Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
            currentPrefabIndex = (currentPrefabIndex + 1) % npcPrefabs.Length;
        }
    }


       void SpawnInitialNPC()
    {
        // Spawn the initial NPC based on the currentPrefabIndex
        GameObject selectedPrefab = npcPrefabs[1];
        Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
