using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Plant : MonoBehaviour, IDamageable
{

    private GameObject player;
    protected int health = 100;
    public GameObject spinePrefab;
    public Transform spinePos;
    //[SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireRate = 2f;
    //public float spineSpeed = 100f;
    public GameObject coinPrefab;
    public int Health
    {
        get { return health; }
        protected set { health = value; }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

      
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
    Instantiate(spinePrefab, spinePos.position, Quaternion.identity);

}

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }
 
    protected virtual void Die()
    {

        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
        Instantiate(coinPrefab, transform.position, Quaternion.identity);

    }
}


    //public override void Start()
    //{
    //    base.Start();
    //    agent.enabled = false; // La planta no se mueve
    //    player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerHealth>(); // Asigna el jugador
    //    StartCoroutine(ContinuousShooting());
    //}

    //public override void Attack(PlayerHealth player)
    //{

    //    base.Attack(player);
    //    ThrowSpine(player);
    //}

    //void ThrowSpine(PlayerHealth player)
    //{
    //    GameObject spine = Instantiate(spinePrefab, firePoint.position, firePoint.rotation);
    //    Vector3 direction = (player.transform.position - firePoint.position).normalized;

    //    Rigidbody2D rb = spine.GetComponent<Rigidbody2D>();
    //    if (rb != null)
    //    {

    //        rb.velocity = direction * spineSpeed;
    //    }
    //}

    //private IEnumerator ContinuousShooting()
    //{
    //    while (true)
    //    {
    //        if (player != null)
    //        {
    //            ThrowSpine(player); // Dispara hacia el jugador
    //        }
    //        yield return new WaitForSeconds(fireRate); // Espera el tiempo entre disparos
    //    }
    //}


    //protected override void Die()
    //{
    //    base.Die();
    //}
