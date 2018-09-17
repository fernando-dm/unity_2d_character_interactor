using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour {
    public int coin;

    void OnTriggerEnter2D(Collider2D other){
        coin++;
        print("Enter");
    }
    void OnTriggerExit2D(Collider2D other)
    {
        print("Exit");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        print("Stay");
    }
}
