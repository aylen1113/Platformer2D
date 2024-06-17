using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    protected int health = 100;
    protected float speed = 2f;
    protected int attackDamage = 10;
    public int Health
    {
        get { return health; }
        protected set { health = value; }
    }

    public float Speed
    {
        get { return speed; }
        protected set { speed = value; }
    }
    public void Movement()
    {

    }
 
    public virtual void Attack(PlayerHealth player)
    {
        if (player != null)
        {
            player.TakeDamage(attackDamage);
        }


    }
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
   
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }
}

