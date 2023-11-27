using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaymentTrigger : MonoBehaviour
{
    public TextMeshPro paymenttext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Debug.Log("Object entered trigger!");
            paymenttext.text="Payment" + "\n" + "recieved";
        }
    }
    
}
