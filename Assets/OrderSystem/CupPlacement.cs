// CupPlacement script
using UnityEngine;

public class CupPlacement : MonoBehaviour
{
    public string cupSize;
    private OrderManager orderManager;
    public int cupNpcID; // Public int to store the npcID on the cup

    private void Start()
    {
        // Find the OrderManager in the scene
        orderManager = FindObjectOfType<OrderManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CupTrigger"))
        {
            // Check if the triggered collider belongs to the cup GameObject
            orderManager.CupPlacedTrigger(cupSize, this); // Pass the CupPlacement script itself to provide reference to the cup
        }
    }
}
