using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNPCs : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a specific tag (you can modify this condition)
        if (other.CompareTag("NPC"))
        {
            // Destroy the object that entered the collider
            Destroy(other.gameObject);
        }
    }
}
