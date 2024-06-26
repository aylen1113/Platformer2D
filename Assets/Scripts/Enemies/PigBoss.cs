using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PigBoss : MonoBehaviour
{
    public int health = 500; 
    public int damage = 50; 
    public float attackCooldown = 2f; 
    protected float lastAttackTime = 0f;

    private Transform playerTransform;
    private bool isDefeated = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastAttackTime + attackCooldown && !isDefeated)
        {
            Attack();
        }
    }

    private void Attack()
    {
        lastAttackTime = Time.time;
        
        PlayerHealth player = playerTransform.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !isDefeated)
        {
            Defeat();
        }
    }

    private void Defeat()
    {
        isDefeated = true;
   
        Debug.Log("Pig Boss defeated! Loading victory screen...");
        SceneManager.LoadScene("VictoryScreen");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                Attack();
            }
        }
    }
}
