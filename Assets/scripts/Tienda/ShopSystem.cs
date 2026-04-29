using UnityEngine;
using System.Collections; 
using System.Collections.Generic;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public Player Player;
    public int Coin; 
    public int Potion; 
    public int Shield; 
    public int Potion_Shield;
    public int Boots;
    public TMP_Text Coin_text; 
    public TMP_Text Potion_text; 
    public TMP_Text Shield_text; 
    public TMP_Text Potion_Shield_text; 
    public TMP_Text Boots_text; 

    void Start()
    {
        Coin = 20; 
        Coin_text.text = Coin.ToString();
    }

    public void BuyPotion()
    {
        if(Coin >= 10)
        {
            Coin -= 10; 
            Coin_text.text = Coin.ToString();

            Potion += 1;
            Potion_text.text = Potion.ToString();

            Player.Heal(1); 
        }
        else
        {
            print("broke ahh"); 
        }
    }
    public void BuyShield()
    {
        if(Coin >= 10)
        {
            Coin -= 10; 
            Coin_text.text = Coin.ToString();

            Shield += 1;
            Shield_text.text = Shield.ToString();
            Player.AddShield();
        }
        else
        {
            print("broke ahh"); 
        }
    }
    public void BuyPotion_Shield()
    {
        if(Coin >= 25)
        {
            Coin -= 25; 
            Coin_text.text = Coin.ToString();

            Potion_Shield += 1;
            Potion_Shield_text.text = Potion_Shield.ToString();
            Player.Heal(1);
            Player.AddShield();
        }
        else
        {
            print("broke ahh"); 
        }
    }
    public void BuyBoots()
    {
        if(Coin >= 15)
        {
            Coin -= 15; 
            Coin_text.text = Coin.ToString();

            Boots += 1;
            Boots_text.text = Boots.ToString();
            Player.AddSpeed(2f);
        }
        else
        {
            print("broke ahh"); 
        }
    }
}