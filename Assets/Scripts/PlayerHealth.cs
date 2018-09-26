using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

public string EndText = "Ganaste";
    
    public void MakeDead()
    {
        EndText = "YouDied";
        EndGame();
        Destroy(gameObject);
    }

    public void EndGame()
    {
            Debug.Log(EndText);
    }
}
