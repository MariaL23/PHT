using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class PickUpHandler : MonoBehaviour
{
    private int cupNpcID; // Variable to store cupNpcID
    private int npcID; // Variable to store NPC ID
    private bool hasCup; // Flag to track if a cup is present in the collider

    public VisualEffect visualEffect;
    public GameObject OrderBag;
    public OrderManager orderManager;

    public float pickupTime = 3f;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the CupPlacement component
        CupPlacement cupPlacement = other.GetComponent<CupPlacement>();
        if (cupPlacement != null)
        {
            if (orderManager.completedOrders.Count > 0)
            {
                // Start the coroutine for delayed action
                StartCoroutine(DelayedActionCoroutine(cupPlacement.cupNpcID, other.gameObject));
            }
        }

        if (other.CompareTag("NPC"))
        {
            StartCoroutine(ByeBag());
        }
    }

    // Coroutine for the delayed action
    private IEnumerator DelayedActionCoroutine(int cupNpcID, GameObject cupObject)
    {
        yield return new WaitForSeconds(2f); // Delay for 2 seconds

        Debug.Log("Cup with id " + cupNpcID + " has entered the collider");
        //visualEffect.Play();
        OrderBag.SetActive(true);
        
        // Store cupNpcID in the variable
        this.cupNpcID = cupNpcID;
        hasCup = true;

        // Destroy the cup object
        Destroy(cupObject);

        // Set cupNpcID in the OrderBagScript
        OrderBag.GetComponent<OrderBagScript>().SetCupNpcID(cupNpcID);
    }

    private IEnumerator ByeBag()
    {

        yield return new WaitForSeconds(pickupTime); // Delay for x seconds has to match the Pickupwaittime in NpcMovement
        OrderBag.SetActive(false);
    }
}
