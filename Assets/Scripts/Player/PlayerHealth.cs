using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public bool isInvincible = false;

    public Slider slider;

    void Start()
    {
        SetMaxHealth(health); 
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

    }

    public void TakeDamage(int amount)
    {
        if (!isInvincible)
        {
            Debug.Log("Damage");
            health -= amount; 
            slider.value = health; 

            if (health <= 0)
            {
                Die();
            }
        }
    }


    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
