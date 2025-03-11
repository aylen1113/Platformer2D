
using UnityEngine;
using UnityEngine.AI;


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


    public GameObject coinPrefab;

    public float chaseRange = 5f;

    protected bool isChasing = false;
    protected bool isGrounded;


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

    public virtual void Start()
    {
        player = GetComponent<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;


        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoTraverseOffMeshLink = false;

        if (agent.isOnNavMesh)
        {
            agent.isStopped = true;
            agent.speed = 0f;
        }

    }
    private void Awake()

    {
        rb = GetComponent<Rigidbody2D>();
        FreezeRotation();
    }

    public virtual void Update()
    {
        if (!agent.isOnNavMesh) return;

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;
            agent.isStopped = false;
            agent.speed = speed;
            Movement();
        }
        else
        {
            isChasing = false;
            agent.speed = 0f;
            agent.isStopped = true;
        }
    }




    public virtual void Movement()
    {
        if (agent != null && agent.enabled)
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
   protected virtual void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        isGrounded = hit.collider != null;
    }

    protected virtual void Die()
    {

        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
        Instantiate(coinPrefab, transform.position, Quaternion.identity);

    }
}

