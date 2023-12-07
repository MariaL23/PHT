using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExitGame();
            Debug.Log("Exit Game");
        }
    }


    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode();
       Debug.Log("Exit Game");
    }
}
