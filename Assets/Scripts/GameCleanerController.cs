using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCleanerController : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().MakeDead();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void StopGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    
}
