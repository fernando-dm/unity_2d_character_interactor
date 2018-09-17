using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public int count;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            count += 1;
            //Destroy(gameObject); // me destruye solo la moneda, pero me deja el cartel de su padre (coinBase)
            Destroy(gameObject.transform.root.gameObject); // me destruye la jerarquia (coinBase)
        }
    }
}
