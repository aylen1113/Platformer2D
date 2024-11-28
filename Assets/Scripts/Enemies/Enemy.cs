using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, IDamageable
{
    protected int health = 100;
    protected float speed = 2f;

    protected int attackDamage = 10;
    protected Rigidbody2D rb;

    protected LayerMask ground;
    protected float distance = 2f;

    protected PlayerHealth player;

    protected Transform target;
    protected NavMeshAgent agent;

    private EnemySpawner spawner;

    public string enemyTypeName;

    //[Header("Patrol Points")]
    //[SerializeField] private Transform leftEdge;
    //[SerializeField] private Transform rightEdge;

    public int Health
    {
        get { return health; }
        protected set { health = value; }
    }

    public float Speed
    {
        get { return speed; }
        protected set { speed = value; }
    }

    private void Start()
    {
        player = GetComponent<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        spawner = FindObjectOfType<EnemySpawner>();

    }
    private void Awake()

    {
        rb = GetComponent<Rigidbody2D>();
        FreezeRotation();
    }

    private void Update()
    {
        Movement();
    }
 
    


    public virtual void Movement()
    {
        {
            agent.SetDestination(target.position);
        }
    }
    private void FreezeRotation()
    {
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                Attack(player);
            }
        }
    }

    public virtual void Attack(PlayerHealth player)
    {

        if (player != null)
        {
            player.TakeDamage(attackDamage);
        }


    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
   
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
        spawner.ReturnEnemyToPool(gameObject, enemyTypeName);

    }
}

