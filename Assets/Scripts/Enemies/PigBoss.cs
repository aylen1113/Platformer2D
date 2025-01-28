using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PigBoss : MonoBehaviour, IDamageable
{
    public int health = 500;
    public int damage = 50;
    public float attackCooldown = 2f;
    protected float lastAttackTime = 0f;

    private Transform target;
    private bool isDefeated = false;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;


    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (Time.time > lastAttackTime + attackCooldown && !isDefeated)
        {
            Attack();
        }
    }

    private void Attack()
    {
        lastAttackTime = Time.time;

        PlayerHealth player = target.GetComponent<PlayerHealth>();
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

        Debug.Log("boss defeated");
        SceneManager.LoadScene("VictoryScreen");
    }

   public void OnCollisionEnter2D(Collision2D collision)
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
