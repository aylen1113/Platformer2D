using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public bool isInvincible = false;

    public void TakeDamage(int amount)
    {
        if (!isInvincible)
        {
            Debug.Log("Damage");
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
      
     //pantalla game over 
    }
}
