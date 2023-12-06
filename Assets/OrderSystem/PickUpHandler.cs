using UnityEngine;
using UnityEngine.VFX;

public class PickUpHandler : MonoBehaviour
{ private int cupNpcID; // Variable to store cupNpcID
    private int npcID; // Variable to store NPC ID
    private bool hasCup; // Flag to track if a cup is present in the collider
    private bool hasNPC; // Flag to track if an NPC is present in the collider
    public VisualEffect visualEffect;

    public GameObject OrderBag;

    // Reference to the OrderManager script
    public OrderManager orderManager;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the CupPlacement component
        CupPlacement cupPlacement = other.GetComponent<CupPlacement>();
        if (cupPlacement != null)
        {   
            if (orderManager.completedOrders.Count > 0){
            int cupNpcID = cupPlacement.cupNpcID;
            Debug.Log("Cup with id " + cupNpcID + " has entered the collider");
            visualEffect.Play();
            OrderBag.SetActive(true);
            // Store cupNpcID in the variable
            
            this.cupNpcID = cupNpcID;
            hasCup = true;
            Destroy(other.gameObject);
            OrderBag.GetComponent<OrderBagScript>().SetCupNpcID(cupNpcID);


            // Check if both cup and NPC are present and have the same ID
            CheckIDs();
           }
        }

        // Check if the entering object has the NPCControl component
        NPCMovement npcControl = other.GetComponent<NPCMovement>();
        if (npcControl != null)
        {
            npcID = npcControl.npcID; // Store NPC ID in the class-level variable
            Debug.Log("NPC with id " + npcID + " has entered the collider");

            hasNPC = true;

            // Check if both cup and NPC are present and have the same ID
            CheckIDs();
        }


    }

    private void OnTriggerExit(Collider other)
    {
        // Reset flags when an object exits the collider
        CupPlacement cupPlacement = other.GetComponent<CupPlacement>();
        if (cupPlacement != null)
        {
            hasCup = false;
        }

        NPCControl npcControl = other.GetComponent<NPCControl>();
        if (npcControl != null)
        {
            hasNPC = false;
        }
    }

    private void CheckIDs()
    {
        // Only call CheckIDs if both cup and NPC have entered
        if (hasCup)
        {
            // Get the first completed order
            if (orderManager.completedOrders.Count > 0)
            {
                int firstCompletedOrderNpcID = orderManager.completedOrders[0].npcID;

                if (cupNpcID == firstCompletedOrderNpcID)
                {
                  
                    Debug.Log("CupNpcID matches the NPC ID in the first completed order!");
                }
                
            }
            else
            {
                Debug.Log("No completed orders yet.");
            }
        }
    }
}
