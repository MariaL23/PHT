using UnityEngine;
using System.Collections;

public class FlaskAnimationtrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject Sirup;
   public bool canTrigger = true; // Flag to control triggering

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTrigger)
        {
            StartCoroutine(AnimateAndWait());
        }
    }

    private IEnumerator AnimateAndWait()
    {
        canTrigger = false; // Disable triggering

        if (Sirup != null)
        {
            anim.SetBool("Touched", true);
            yield return new WaitForSeconds(0.5f); // Wait for pour duration
            Sirup.SetActive(true);
            yield return new WaitForSeconds(1f); // Wait for stop duration
            Sirup.SetActive(false);
            anim.SetBool("Touched", false);
        }

        yield return new WaitForSeconds(1.5f); // Wait for 2 seconds before enabling triggering again
        canTrigger = true; // Enable triggering again
    }
}
