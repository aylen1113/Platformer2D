using System.Collections;
using UnityEngine;

public class Duck : Enemy

{
    [SerializeField] private float flyHeight = 5f; 
    [SerializeField] private float diveSpeed = 7f; 
    [SerializeField] private float returnSpeed = 3f; 
    [SerializeField] private float attackCooldown = 4f; 
    [SerializeField] private int damage = 15; 

    private Vector3 originalPosition; 
    private Transform playerTransform;
    private bool isAttacking = false; 

    private float lastAttackTime = 0f;

    public override void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        originalPosition = transform.position; 
    }

    public override void Update()
    {
        base.Update();

        CheckGround();

        if (!isGrounded)
        {
            agent.isStopped = true;
        }
        else if (isChasing)
        {
            agent.isStopped = false;
        }


        if (!isAttacking && Time.time >= lastAttackTime + attackCooldown)
        {
            StartCoroutine(DiveAttack());
        }
    }

    private IEnumerator DiveAttack()
    {
        isAttacking = true;

    
        Vector3 flyPosition = originalPosition + Vector3.up * flyHeight;
        yield return MoveToPosition(flyPosition, returnSpeed);

      
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position;
            yield return MoveToPosition(targetPosition, diveSpeed);

      
            if (Vector3.Distance(transform.position, playerTransform.position) < 1f)
            {
                PlayerHealth player = playerTransform.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }
        }

     
        yield return MoveToPosition(originalPosition, returnSpeed);

     
        lastAttackTime = Time.time;
        isAttacking = false;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float speed)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}

