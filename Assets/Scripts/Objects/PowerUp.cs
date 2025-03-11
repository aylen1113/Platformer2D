using System.Collections;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, ICollectable
{
    public bool effectApplied;
    protected float duration = 5f;

    public void Collect()
    {

        StartCoroutine(PowerUpDuration(GameObject.FindWithTag("Player").GetComponent<PlayerMovement>()));
        Destroy(gameObject);
    }

    public abstract void ApplyPowerup(PlayerMovement playerMovement);

  
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