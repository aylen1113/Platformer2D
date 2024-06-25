using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, ICollectable
{


    public void Collect()
    {
        ApplyPowerup();
        Destroy(gameObject); 
    }

    public abstract void ApplyPowerup();

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCollectPowerup(other.gameObject);
        }
    }

    protected virtual void PlayerCollectPowerup(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            ApplyPowerup(); 
            Destroy(gameObject); 
        }
    }
}
