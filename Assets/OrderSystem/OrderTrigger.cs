using UnityEngine;

public class OrderTrigger : MonoBehaviour
{
    private bool canTrigger = true;
   public float cooldownTime = 30f;

    void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("NPC"))
        {
            // Call the method in the OrderManager when the NPC enters the table trigger
            FindObjectOfType<OrderManager>().NPCReachedTrigger();
            Debug.Log("NPC reached trigger");

            // Set the cooldown
            canTrigger = false;
            Invoke("ResetCooldown", cooldownTime);
        }
    }

    void ResetCooldown()
    {
        canTrigger = true;
    }
}