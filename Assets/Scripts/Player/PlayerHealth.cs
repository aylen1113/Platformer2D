using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public bool isInvincible = false;

    private void Awake()
    {
        maxHealth = 100; 
    }
    public override void TakeDamage(int amount)
    {
        if (!isInvincible)
        {
            Debug.Log("player took damage");
            base.TakeDamage(amount);
        }
    }

    protected override void Die()
    {
        Debug.Log("player died");
        SceneManager.LoadScene("GameOver");
    }
}
