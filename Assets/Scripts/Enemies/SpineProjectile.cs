using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineProjectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
