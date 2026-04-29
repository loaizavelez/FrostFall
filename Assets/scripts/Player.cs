using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public bool hasShield = false;
    public float speed = 5f;

    public void Heal(int amount)
    {
        health += amount;
        if (health > 3)
            health = 3; // Max health is 3
    }

    public void AddShield()
    {
        hasShield = true;
    }

    public void AddSpeed (float amount)
    {
        speed += amount;
    }
}
