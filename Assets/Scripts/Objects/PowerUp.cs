using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, ICollectable
{
    public bool effectApplied;
    protected float duration = 5f;

    public void Collect()
    {
        // Llamamos a PowerUpDuration pasando el PlayerMovement
        StartCoroutine(PowerUpDuration(GameObject.FindWithTag("Player").GetComponent<PlayerMovement>()));
        Destroy(gameObject);
    }

    public abstract void ApplyPowerup(PlayerMovement playerMovement);

    // Implementación de PowerUpDuration desde la interfaz ICollectable
    public IEnumerator PowerUpDuration(PlayerMovement playerMovement)
    {
        effectApplied = true;
        ApplyPowerup(playerMovement);

        yield return new WaitForSeconds(duration);

        effectApplied = false;
        RemovePowerup(playerMovement);

        Destroy(gameObject);
    }

    protected abstract void RemovePowerup(PlayerMovement playerMovement);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

}