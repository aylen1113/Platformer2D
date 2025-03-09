using UnityEngine;
using UnityEngine.Assertions.Must;

public class SpineProjectile : MonoBehaviour
{

    private GameObject player;


    //[SerializeField] private float speed = 10f;
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


        float rot = Mathf.Atan2 (-direction.y, -direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

 void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }


    //    player = GameObject.FindGameObjectWithTag
    //    rb = GetComponent<Rigidbody2D>();

    //    if (rb != null)
    //    {
    //        rb.velocity = transform.right * speed; // Mueve el proyectil hacia adelante
    //    }

    //    Destroy(gameObject, 3f); // Se destruye después de 3 segundos
    //}

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
