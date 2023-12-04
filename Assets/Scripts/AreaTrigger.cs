using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public Animator npcAnimator; // Reference to the NPC's Animator component
    public string enterQueueTrigger = "EnterQueue"; // The boolean parameter name

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the trigger is activated by the player
        {
            npcAnimator.SetBool(enterQueueTrigger, true); // Set the boolean parameter to true
        }
    }
}