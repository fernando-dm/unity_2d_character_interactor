using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject reward;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //efecto sparkle
            Instantiate(reward, transform.position, Quaternion.identity); //lo instancio en mi position sin rotation(quaternion)
            
            //agrego moneda
            other.gameObject.GetComponent<PlayerInventory>().AddCoins();

            //Destroy(gameObject); // me destruye solo la moneda, pero me deja el cartel de su padre (coinBase)
            Destroy(gameObject.transform.root.gameObject); // me destruye la jerarquia (coinBase)
        }
    }
}