
using UnityEngine;
using UnityEngine.SceneManagement;


public class PigBoss : MonoBehaviour, IDamageable
{

    private GameObject player;
    protected int health = 500;
    private GameObject bossProjectile;
    public Transform projectilePos;
    //[SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireRate = 2f;
    //public float spineSpeed = 100f;
    public GameObject coinPrefab;
    private BossHealth bossHealth;
    private Transform target;
    //private bool isDefeated = false;



    // Start is called before the first frame update

    public int Health
    {
        get { return health; }
        protected set { health = value; }
    }

    void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.LogError("No se encuentra el player");
            }
            else
            {
                target = player.transform;
            }

            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                bossProjectile = gameManager.BossProjectilePrefab;
            }

            // Find BossHealth component
            bossHealth = GetComponent<BossHealth>();
            if (bossHealth == null)
            {
                Debug.LogError("PigBoss: BossHealth component not found!");
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
