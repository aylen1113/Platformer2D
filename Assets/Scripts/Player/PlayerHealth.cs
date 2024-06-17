using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private int health = 100;

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {

    
     if (health <= 0)
        {

          //pantalla game over
}
    }
    public void Heal(int amount)
    {
        //curar
    }
}

