using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        ShopSystem shop = other.GetComponent<ShopSystem>();

        if (shop != null)
        {
            shop.Coin += value;
            shop.Coin_text.text = shop.Coin.ToString();

            Destroy(gameObject);
        }
    }
}