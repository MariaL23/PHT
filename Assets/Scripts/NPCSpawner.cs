using System.Collections;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject[] npcPrefabs;  // Array of NPC prefabs to choose from
    public Transform spawnPoint;     // Point where NPCs will be spawned
    public float spawnInterval = 240f;  // Time between NPC spawns in seconds (4 minutes)
    
    public int npcCounter = 1;
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

            
            GameObject selectedPrefab = npcPrefabs[currentPrefabIndex];
            GameObject spawnedNPC = Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);

            // Spawn the selected NPC at the spawn point
            
            currentPrefabIndex = (currentPrefabIndex + 1) % npcPrefabs.Length;

             NPCMovement npcMovement = spawnedNPC.GetComponent<NPCMovement>();
            if (npcMovement != null)
            {
                npcMovement.npcID = npcCounter;
            }

             npcCounter++;
        }
    }


       void SpawnInitialNPC()
    {
       GameObject selectedPrefab = npcPrefabs[2];
        GameObject spawnedNPC = Instantiate(selectedPrefab, spawnPoint.position, spawnPoint.rotation);

        // Set the npcID in the NPCMovement script
        NPCMovement npcMovement = spawnedNPC.GetComponent<NPCMovement>();
        if (npcMovement != null)
        {
            npcMovement.npcID = npcCounter;
        }

        npcCounter++;
    }
}
