using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacement : MonoBehaviour
{
    public string itemType; // Set this in the Inspector for each item GameObject
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
            // Call the ItemPlacedTrigger method from OrderManager and pass the item type
            orderManager.ItemPlacedTrigger(itemType);
        }
    }
}
