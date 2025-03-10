using System.Collections.Generic;
using UnityEngine;

public class Apple : PowerUp
{
    public int healthRestoreAmount = 20;

    public override void ApplyPowerup(PlayerMovement playerMovement)
    {
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(-healthRestoreAmount);
        }
    }
    protected override void RemovePowerup(PlayerMovement playerMovement)
    {
      
    }
}
