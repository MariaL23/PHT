using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacement : MonoBehaviour
{
    private int npcID;
    public string itemType;
    private OrderManager orderManager;

    private void Start()
    {
        // Find the OrderManager in the scene
        orderManager = FindObjectOfType<OrderManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemTrigger"))
        {
            // Check if the cup has been placed correctly
            if (orderManager.IsCupPlaced())
            {
                // Call the ItemPlacedTrigger method from OrderManager and pass the item type
                orderManager.ItemPlacedTrigger(itemType, npcID);
            }
            else
            {
               
            }
        }
    }
}
