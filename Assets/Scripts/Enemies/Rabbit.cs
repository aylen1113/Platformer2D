using UnityEngine;

public class Rabbit : Enemy
{
    protected float jumpForce = 5f;
    protected float attackCooldown = 2f;
    protected float lastAttackTime = 0f;
    protected bool isJumping = false;
    public int damage = 10;

    private Transform playerTransform;
    private Vector3 originalPosition;

    [SerializeField] private LayerMask groundLayer;

    public override void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        originalPosition = transform.position; // Guarda la posición inicial
    }
    public override void Update()
    {
        base.Update(); // Llama al Update de Enemy para conservar su IA

        CheckGround();

        if (!isGrounded)
        {
            agent.isStopped = true;
        }
        else if (isChasing)
        {
            agent.isStopped = false;
        }


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
        if (isGrounded) // Ensure it only jumps when grounded
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // More reliable than AddForce
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            lastAttackTime = Time.time;
        }
    }
    protected override void CheckGround()
    {
        base.CheckGround(); // Call the base class CheckGround() if necessary

        // Custom ground check for Rabbit
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red); // Debugging
    }


    protected override void Die()
    {
        base.Die();
    }
}
