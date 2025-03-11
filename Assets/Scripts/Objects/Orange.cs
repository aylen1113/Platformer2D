using UnityEngine;

public class Orange : PowerUp
{
    public float speedMultiplier = 2f;
    private float originalSpeed = 5;

    public override void ApplyPowerup(PlayerMovement playerMovement)
    {
        //originalSpeed = playerMovement.speed; // Store the original speed
        playerMovement.moveSpeed *= speedMultiplier; // Increase speed by the multiplier
    }

    protected override void RemovePowerup(PlayerMovement playerMovement)
    {
        playerMovement.moveSpeed = originalSpeed; // Revert to the original speed
    }
}
