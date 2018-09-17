using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public int coins;

	public void AddCoins() {
        coins++;
        print("Coins Collected" + coins);
		
	}
}
