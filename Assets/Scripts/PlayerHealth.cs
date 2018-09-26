using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public string EndText = "Ganaste";
    public Image EndScreen;    
    
    public void MakeDead()
    {
        EndText = "YouDied";
        EndGame();
        EndScreen.color = Color.white;  // con esto me habilita la imagen que deshabilite con los alpha
//        Instantiate(EndScreen, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void EndGame()
    {
            Debug.Log(EndText);
    }
}
