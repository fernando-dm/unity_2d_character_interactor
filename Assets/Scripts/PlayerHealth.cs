using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public string EndText = "Ganaste";
    public Image EndScreen;
    public CanvasGroup EndCGP;
    public Text EndGameUIText;
    
    public void MakeDead()
    {
        EndText = "YouDied";
        EndGame();
        EndScreen.color = Color.white;  // con esto me habilita la imagen que deshabilite con los alpha (marco rojo)
//        Instantiate(EndScreen, transform.position, Quaternion.identity);
        Destroy(gameObject);
//        Destroy(gameObject.transform.root.gameObject);
    }

    public void EndGame()
    {
        EndGameUIText.text= EndText;
        EndCGP.alpha = 1; // activo cartel de fin de juego (EndGamePanel)
        Debug.Log(EndText);
        Destroy(gameObject);
    }
}
