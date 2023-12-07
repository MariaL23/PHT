using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PaymentSystem : MonoBehaviour
{
   public int totalPayment = 0;

   public TextMeshPro earningsText;

   public GameObject winText;

    public int winAmount = 200;
    
    void Update()
    {
        earningsText.text = "Total Amount Earned: " + totalPayment;
        if (totalPayment >= winAmount)
        {
            Debug.Log("Earnings = " + totalPayment + "You win!");
            winText.SetActive(true);
            
            // Load the win scene
            StartCoroutine(Wait());
        }
    }

    // Method to add payment amount
    public void AddPayment(int amount)
    {
        totalPayment += amount;
        Debug.Log("Payment added: " + amount + ". Total payment: " + totalPayment);

   
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
         SceneManager.LoadScene(2);
    }
}