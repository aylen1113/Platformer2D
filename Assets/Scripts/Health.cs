using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int currentHealth;

    public Slider healthSlider;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected abstract void Die(); 
}
