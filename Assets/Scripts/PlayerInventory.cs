using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int Coins=0;


    public Text CoinText;

    void Start()
    {
        CoinText.text = Coins.ToString();
    }

    public void AddCoins()
    {
        Coins++;
        CoinText.text = Coins.ToString();
        print("Coins Collected" + Coins);
        if (Coins==3)
            GetComponent<PlayerHealth>().EndGame();
    }
}