using UnityEngine;
using System.Collections;

public class OrderTrigger : MonoBehaviour
{
    private bool canTrigger = true;
    public float cooldownTime = 30f;

    void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("NPC"))
        {
        

            // Set the cooldown and start the coroutine
            canTrigger = false;
            StartCoroutine(ResetCooldown(cooldownTime));
        }
    }

   IEnumerator ResetCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reset the cooldown after the specified delay
        canTrigger = true;
    }
}