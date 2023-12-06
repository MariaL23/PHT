using System.Collections;
using UnityEngine;

public class NPCLeaving : MonoBehaviour
{
    public Animator animator;
    public float waitTimeAtCounter = 2f;
    public Transform exitWaypoint;

    public void PerformLeavingAction(int npcID)
    {
        StartCoroutine(LeavingRoutine(npcID));
    }

    IEnumerator LeavingRoutine(int npcID)
    {
        // Play leaving animation
        if (animator != null)
        {
            animator.SetTrigger("LeaveAnimationTrigger");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        }

        // Wait for a specified time at the counter
        yield return new WaitForSeconds(waitTimeAtCounter);

        // Move to the exit waypoint
        MoveToExitWaypoint(npcID);
    }

    private void MoveToExitWaypoint(int npcID)
    {
        // Implement logic to move NPC to the exit waypoint
        // You can reuse MoveToPoint or create a similar method
        // ...

        Debug.Log("NPC with ID " + npcID + " is moving to the exit waypoint.");
    }
}
