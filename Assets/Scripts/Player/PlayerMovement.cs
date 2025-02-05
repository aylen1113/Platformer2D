using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f;
    public float speed = 5f;
    public bool grounded = true;
    private float moveInput;

    private Rigidbody2D rb;
    Animator animator;
    //private bool isGrounded;

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
        //check if the collsion is happening with a game object with "ground" tag.
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

        // cambiar la dirección 
        if (moveInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4); 
        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4); 

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //Debug.Log("jump force: " + jumpForce);
        }
    }

    public bool canAttack()
    {
        return moveInput == 0 && grounded;
    }
}
