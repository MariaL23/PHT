using UnityEngine;
using System.Collections;

public class BobaSpoon : MonoBehaviour
{
    public GameObject Bobas; 
    public GameObject Bobas2;// Reference to the object you want to activate

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlackBobaBowl"))
        {
             // Activate the specified object
            if (Bobas != null)
            {
                Bobas.SetActive(true);
                Bobas2.SetActive(false);
              
            }
           
          
        }
        
         if (other.CompareTag("Boba2Bowl"))
        {
             // Activate the specified object
            if (Bobas2 != null)
            {
                Bobas2.SetActive(true);
                Bobas.SetActive(false);
               
            }
          
        }

          if (other.CompareTag("ItemTrigger"))
        {
             // Activate the specified object
            if (Bobas2 != null)
            {
               StartCoroutine(WaitDeactivate());
               
            }
          
        }


    }

    private IEnumerator WaitDeactivate()
    {
        yield return new WaitForSeconds(0.2f);
        Bobas.SetActive(false);
        Bobas2.SetActive(false);
    }

}
