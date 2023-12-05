using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCControl : MonoBehaviour
{
     public int npcID;  // Assign a unique ID to each NPC in the Unity Editor
    public OrderManager orderManager;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("OrderTable"))  
        {      
         orderManager.NPCReachedTrigger(npcID);
        }
        
    }

     public void BagPickUp(int cupNpcID)
    {
        // Check if the NPC's ID matches the provided cupNpcID
        if (npcID == cupNpcID)
        {
            Debug.Log("NPC with ID " + npcID + " picked up the bag.");
           
        }
        else
        {
            Debug.Log("NPC with ID " + npcID + " cannot pick up the bag. IDs do not match.");
        }
    }
}
