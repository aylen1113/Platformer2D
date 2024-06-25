using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Enemy
{
    public float jumpForce = 5f; 
    public float attackCooldown = 2f; 
    private float lastAttackTime = 0f;
    private bool isJumping = false;
    public int damage = 10; 

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.time > lastAttackTime + attackCooldown && !isJumping)
        {
            Jump();
        }
    }

    public override void Attack(PlayerHealth player)
    {
        base.Attack(player);
        player.TakeDamage(damage);
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            base.OnCollisionEnter2D(collision);
        }
        

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            lastAttackTime = Time.time;
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}
