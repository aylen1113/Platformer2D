using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : Health
{
    private bool isDefeated = false;
    private void Awake()
    {
        maxHealth = 500;
    }
    public override void TakeDamage(int amount)
    {
       
            Debug.Log("enemy took damage");
            base.TakeDamage(amount);

    }
    protected override void Die()
    {
        if (!isDefeated)
        {
            isDefeated = true;
            Debug.Log("jefe derrotado");
            SceneManager.LoadScene("VictoryScreen");
        }
    }
}
