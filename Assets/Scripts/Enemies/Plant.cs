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

    [SerializeField] protected float fireRate = 2f;

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
