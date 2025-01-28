using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Enemy
{

    public GameObject spinePrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireRate = 2f;


    //private void Update()
    //{
    //    base.Movement();
    //}

    public override void Start()
    {
        base.Start(); // Llama al Start de la clase base
        agent.enabled = false; // Desactiva el NavMeshAgent para que no se mueva
        StartCoroutine(ContinuousShooting());
    }

    public override void Attack(PlayerHealth player)
    {

        base.Attack(player);
        ThrowSpine(player);
    }

    void ThrowSpine(PlayerHealth player)
    {

        GameObject spine = Instantiate(spinePrefab, firePoint.position, firePoint.rotation);


        Vector3 direction = (player.transform.position - firePoint.position).normalized;
        spine.transform.forward = direction;
    }

    private IEnumerator ContinuousShooting()
    {
        while (true)
        {
            if (player != null)
            {
                ThrowSpine(player); // Dispara hacia el jugador
            }
            yield return new WaitForSeconds(fireRate); // Espera el tiempo entre disparos
        }
    }


    protected override void Die()
    {
        base.Die();
    }
}