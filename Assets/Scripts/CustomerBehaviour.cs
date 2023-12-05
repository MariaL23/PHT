using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CustomerBehaviour : MonoBehaviour
{
    public Transform doorEntrance;
    public Transform doorExit;
    public Transform orderPoint;

    public float waitTimeBeforeOrder = 2f; // Time to wait before placing an order
    public float extraWaitTime = 2f; // Extra time after completing the order

    private NavMeshAgent agent;
    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(CustomerBehaviourRoutine());
    }

    IEnumerator CustomerBehaviourRoutine()
    {
        // Enter through the door
        MoveToLocation(doorEntrance.position);
        animator.SetTrigger("walkingTrigger");
        yield return new WaitUntil(() => HasReachedDestination());

        // Wait briefly before placing an order
        animator.SetTrigger("Idle1Trigger");
        yield return new WaitForSeconds(waitTimeBeforeOrder);

        // Move to the order placement point
        MoveToLocation(orderPoint.position);
        animator.SetTrigger("TalkingTrigger");
        yield return new WaitUntil(() => HasReachedDestination());

        // Place an order (Add your order placing logic here)

          // Move to the waiting place
        MoveToLocation(orderPoint.position);
        animator.SetTrigger("walkingTrigger");
        yield return new WaitUntil(() => HasReachedDestination());

        // Wait for the order
        animator.SetTrigger("phoneTrigger");
        yield return new WaitForSeconds(extraWaitTime);

          // Move to the order payment point
        MoveToLocation(orderPoint.position);
        animator.SetTrigger("walkingTrigger");
        yield return new WaitUntil(() => HasReachedDestination());

        // Payment animation
        MoveToLocation(doorExit.position);
        animator.SetTrigger("paymentTrigger");
        yield return new WaitUntil(() => HasReachedDestination());

          // Exit game
        MoveToLocation(orderPoint.position);
        animator.SetTrigger("walkingTrigger");
        yield return new WaitUntil(() => HasReachedDestination());

        // Leave through the door
        // Optionally, you can destroy or deactivate the GameObject here
    }

    void MoveToLocation(Vector3 destination)
    {
        print(destination);
        agent.SetDestination(destination);
    }

    bool HasReachedDestination()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }
}