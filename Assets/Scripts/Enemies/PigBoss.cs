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

    public void Start()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            bossProjectile = gameManager.BossProjectilePrefab;
        }

        target = GameObject.FindGameObjectWithTag("Player").transform;
        //bossProjectile = GameObject.FindGameObjectWithTag("BossProjectile");
        projectilePos = GameObject.FindGameObjectWithTag("PigBoss").transform;

    }
 
    
   void Update()
    {
      

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 5)
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
    Instantiate(bossProjectile, projectilePos.position, Quaternion.identity);

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
