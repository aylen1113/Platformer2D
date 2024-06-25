using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Enemy
{

    //public GameObject spinePrefab; 
    //public Transform firePoint; 
   
    public override void Attack(PlayerHealth player)
    {
        base.Attack(player);
        ThrowSpine(player);
    }

    void ThrowSpine(PlayerHealth player)
    {
 
        //GameObject spine = Instantiate(spinePrefab, firePoint.position, firePoint.rotation);

       
        //Vector3 direction = (player.transform.position - firePoint.position).normalized;
        //spine.transform.forward = direction;
    }

    protected override void Die()
    {
        base.Die();
    }
}