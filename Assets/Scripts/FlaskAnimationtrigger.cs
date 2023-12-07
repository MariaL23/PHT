using UnityEngine;
using System.Collections;

public class FlaskAnimationtrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject Sirup;
   

    private void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            if (Sirup != null)
            {
               StartCoroutine(WaitPour());
               
            }
            anim.SetBool("Touched", true); 
        }
    }
     private void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
           if (Sirup != null)
            {
                Sirup.SetActive(false);
               
            }
            anim.SetBool("Touched", false); 

        }
    }
    private IEnumerator WaitPour()
    {
        yield return new WaitForSeconds(0.5f);
        Sirup.SetActive(true);
    }


}
