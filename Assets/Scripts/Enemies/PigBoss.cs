using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PigBoss :  MonoBehaviour, IDamageable
{

    private GameObject player;
   protected int health = 500;
    private GameObject bossProjectile;
    public Transform projectilePos;
    //[SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireRate = 2f;
    //public float spineSpeed = 100f;
    public GameObject coinPrefab;

    private Transform target;
    private bool isDefeated = false;



    // Start is called before the first frame update
   
    public int Health
    {
        get { return health; }
        protected set { health = value; }
    }

    void Start()
    {
        // Ensure player is assigned
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("PigBoss: No GameObject found with the 'Player' tag! Make sure the player is tagged correctly.");
        }
        else
        {
            target = player.transform;
        }

        // Get the projectile prefab from GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            bossProjectile = gameManager.BossProjectilePrefab;
        }
        else
        {
            Debug.LogError("PigBoss: GameManager not found in the scene. Make sure a GameManager exists.");
        }

        // Ensure projectilePos is assigned
        if (projectilePos == null)
        {
            Debug.LogWarning("PigBoss: projectilePos is not assigned in the Inspector. Please assign a valid Transform.");
        }
    }


    void Update()
    {
      

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            fireRate += Time.deltaTime;

            if (fireRate > 2)
            {
                fireRate = 0;
                Shoot();
            }

        }

    }

    void Shoot()
    {
        if (bossProjectile == null)
        {
            Debug.LogError("PigBoss: bossProjectile is not assigned!");
            return;
        }

        if (projectilePos == null)
        {
            Debug.LogError("PigBoss: projectilePos is not assigned!");
            return;
        }

        // Calculate direction
        Vector3 direction = (player.transform.position - projectilePos.position).normalized;

        // Instantiate the projectile
        GameObject projectile = Instantiate(bossProjectile, projectilePos.position, Quaternion.identity);

        // Rotate the projectile to face the player
        projectile.transform.right = direction; // Assumes the projectile's forward direction is along the X-axis

        // Apply movement to the projectile (if it has Rigidbody)
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * 5f; // Adjust speed as needed
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !isDefeated)
        {
            Defeat();
        }
    }

    private void Defeat()
    {
        isDefeated = true;

        Debug.Log("boss defeated");
        SceneManager.LoadScene("VictoryScreen");
    }

   //public void OnCollisionEnter2D(Collision2D collision)
   // {
   //     if (collision.gameObject.CompareTag("Player"))
   //     {
   //         PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
   //         if (player != null)
   //         {
   //             Attack();
   //         }
   //     }
   // }
}
