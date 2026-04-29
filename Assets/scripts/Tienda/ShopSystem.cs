using UnityEngine;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public int Coin; 
    public int Potion; 
    public Text Coin_text; 
    public Text Potion_text; 

    void Start()
    {
        
    }

    public void BuyPotion()
    {
        if(Coin >= 10)
        {
            Coin -= 10; 
            Coin_text.text = Coin .ToString();

            Potion += 1;
            Potion_text.text = Potion.ToString();
        }
        else
        {
            print("broke ahh"); 
        }
    }
}
