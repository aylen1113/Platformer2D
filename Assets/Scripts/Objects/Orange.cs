using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : PowerUp
{
    public float speedIncreaseAmount = 5f; 
    public float duration = 5f; 

    public override void ApplyPowerup()
    {
        PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            StartCoroutine(IncreaseSpeed(playerMovement));
        }
    }

    private IEnumerator IncreaseSpeed(PlayerMovement playerMovement)
    {
        playerMovement.speed += speedIncreaseAmount;
        yield return new WaitForSeconds(duration);
        playerMovement.speed -= speedIncreaseAmount;
    }
}
