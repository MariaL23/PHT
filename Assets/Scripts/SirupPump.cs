using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirupPump : MonoBehaviour
{
    public GameObject Sirup;

    void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
             // Activate the specified object
            if (Sirup != null)
            {
                Sirup.SetActive(true);
               
            }
           
          
        }
        
    }
}
