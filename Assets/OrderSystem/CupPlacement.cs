// CupPlacement script
using UnityEngine;

public class CupPlacement : MonoBehaviour
{
    public string cupSize; // Set this in the Inspector for each cup GameObject
    private OrderManager orderManager;

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
             
                orderManager.CupPlacedTrigger(cupSize);
               
           
           
        }

        else{
            Debug.Log("CupPlacedTrigger called but CupPlacedTrigger is not called");
        }
    }
}
