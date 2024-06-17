using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Attack(PlayerHealth player)
    {
        if (player != null)
        {
            player.TakeDamage(15);

        }
    }

    protected override void Die()
    {
        base.Die();
    }
}
