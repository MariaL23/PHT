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
}
