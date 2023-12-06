using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonClick : MonoBehaviour
{
   
    public Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ButtonClicked(); // Kald funktionen med knappens ID
        }
    }

    void ButtonClicked()
    {
        // Udfør handling baseret på knappens ID
         Debug.Log("Start Game");
            //animator.SetTrigger("ChangeColorTrigger");
            SceneManager.LoadScene(0);
    }

}