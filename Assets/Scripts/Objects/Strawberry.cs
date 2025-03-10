using UnityEngine;

public class Strawberry : PowerUp
{
    public float jumpForceMultiplier = 1.5f;
    private float originalJumpForce = 7;

    public override void ApplyPowerup(PlayerMovement playerMovement)
    {
        //originalJumpForce = playerMovement.jumpForce; // Store the original jump force
        playerMovement.jumpForce *= jumpForceMultiplier; // Increase jump force by the multiplier
    }

    protected override void RemovePowerup(PlayerMovement playerMovement)
    {
        playerMovement.jumpForce = originalJumpForce; // Revert to the original jump force
    }
}
