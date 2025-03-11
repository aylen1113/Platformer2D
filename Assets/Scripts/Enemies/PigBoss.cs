using UnityEngine;
using UnityEngine.SceneManagement;


public class PigBoss : MonoBehaviour, IDamageable
{

    private GameObject player;
    protected int health = 500;
    private GameObject bossProjectile;
    public Transform projectilePos;
    [SerializeField] protected float fireRate = 2f;

    public GameObject coinPrefab;
    private BossHealth bossHealth;
    private Transform target;



    public int Health
    {
        get { return health; }
        protected set { health = value; }
    }

    void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player");
        
           target = player.transform;
           
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                bossProjectile = gameManager.BossProjectilePrefab;
            }

            bossHealth = GetComponent<BossHealth>();
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
     
        Vector3 direction = (player.transform.position - projectilePos.position).normalized;

        GameObject projectile = Instantiate(bossProjectile, projectilePos.position, Quaternion.identity);

        projectile.transform.right = direction;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * 5f;
        }
    }
    public void TakeDamage(int amount)
    {
        if (bossHealth != null)
        {
            bossHealth.TakeDamage(amount);
        }
    }
}
