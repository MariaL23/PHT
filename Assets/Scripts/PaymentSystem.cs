using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PaymentSystem : MonoBehaviour
{
   public int totalPayment = 0;

   public TextMeshPro earningsText;

   public GameObject winText;
    public TextMeshPro TextWin;

    public float waitTime = 10f;

    public int winAmount = 200;

    public TextMeshPro TodaysGoal;
    

    void Start()
    {
        TodaysGoal.text = "Today's Goal:" + winAmount + "Chinglings";
    }
    void Update()
    {
        earningsText.text = "Total Amount Earned: \n"  + totalPayment;
        if (totalPayment >= winAmount)
        {   
            TextWin.text = "Congratulations!\n You earned\n" + totalPayment + "Chinglings.\nYour Shift is ending..";
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
        yield return new WaitForSeconds(waitTime);
         SceneManager.LoadScene(2);
    }


}