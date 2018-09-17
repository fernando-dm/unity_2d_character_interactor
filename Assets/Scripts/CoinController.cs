using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            other.gameObject.GetComponent <PlayerInventory>().AddCoins();

            //Destroy(gameObject); // me destruye solo la moneda, pero me deja el cartel de su padre (coinBase)
            Destroy(gameObject.transform.root.gameObject); // me destruye la jerarquia (coinBase)
        }
    }
}
