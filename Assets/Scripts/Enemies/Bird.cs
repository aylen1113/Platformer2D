using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy
{
    protected float diveSpeed = 5f; 
    protected float attackCooldown = 3f; 
    protected float lastAttackTime = 0f;
    protected int damage = 10; 

    private Transform playerTransform;
    private bool isDiving = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        base.Movement();
        if (Time.time > lastAttackTime + attackCooldown && !isDiving)
        {
            StartCoroutine(DiveAttack());
        }
    }

    public override void Attack(PlayerHealth player)
    {
        base.Attack(player);
        player.TakeDamage(damage);
    }

    IEnumerator DiveAttack()
    {
        isDiving = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = playerTransform.position;

        float diveDuration = Vector3.Distance(startPosition, targetPosition) / diveSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < diveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / diveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        lastAttackTime = Time.time;
        isDiving = false;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDiving && collision.gameObject.CompareTag("Player"))
        {
            base.OnCollisionEnter2D(collision);
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}
