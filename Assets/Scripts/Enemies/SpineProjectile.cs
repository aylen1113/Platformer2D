using UnityEngine;
using UnityEngine.Assertions.Must;

public class SpineProjectile : MonoBehaviour
{

    private GameObject player;


    [SerializeField] private int damage = 10;
    private Rigidbody2D rb;

    public float force;

    private float timer;
     void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position; 

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    }

 void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
