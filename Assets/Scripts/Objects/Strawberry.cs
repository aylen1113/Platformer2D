using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : PowerUp
{
    public float invincibilityDuration = 5f; // Duration of invincibility

    public override void ApplyPowerup()
    {
        PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            StartCoroutine(GrantInvincibility(playerHealth));
        }
    }

    private IEnumerator GrantInvincibility(PlayerHealth playerHealth)
    {
        playerHealth.isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        playerHealth.isInvincible = false;
    }
}
