using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f;
   
    public bool grounded = true;
    private float moveInput;

    private Rigidbody2D rb;
    Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("isJumping", !grounded);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            animator.SetBool("isJumping", !grounded);
        }

    }


    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yspeed", rb.velocity.y);

        // cambiar la direcci�n 
        if (moveInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4); 
        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4); 

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
           
        }
    }

    public bool canAttack()
    {
        return moveInput == 0 && grounded;
    }
}
