using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCaller : MonoBehaviour
{
    public List<int> readyNPCIDs = new List<int>();
    public List<int> readyOrders = new List<int>();

    public void AddReadyNPC(int npcID)
    {
        // Add the NPC ID to the list of ready NPCs
        readyNPCIDs.Add(npcID);

        // Optionally, you can perform other actions when an NPC is ready
        Debug.Log("NPC with ID " + npcID + " is ready!");

    
    }
      public void AddReadyOrder(int finisedOrderID)
    {
        // Add the NPC ID to the list of ready NPCs
        readyOrders.Add(finisedOrderID);

        // Optionally, you can perform other actions when an NPC is ready
        Debug.Log("Order with ID " + finisedOrderID+ " is ready!");
        
    
    }



   

   void OnApplicationQuit()
   {
    readyNPCIDs.Clear();
    readyOrders.Clear();
   }

     private void OnDisable()
    {
        // Clear the lists when the script instance is being destroyed (exiting play mode)
        readyNPCIDs.Clear();
        readyOrders.Clear();
    }
}
