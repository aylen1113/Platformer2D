using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerups : MonoBehaviour, ICollectable
{
    [SerializeField] protected float duracionDeEfecto;
    [SerializeField] protected GameObject jugador;
    [SerializeField] protected int valorAgregado;
    [SerializeField] public bool efectoActivado;
    [SerializeField] protected SpriteRenderer spriteRenderer;




    protected void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        efectoActivado = true;
    }


    protected abstract void aplicar();


    protected IEnumerator DuracionDePowerUp()
    {
        efectoActivado = true;
        aplicar();

        yield return new WaitForSeconds(duracionDeEfecto);

        efectoActivado = false;
        aplicar();
        Collect();

    }

    public void Collect()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            spriteRenderer.enabled = false;

            StartCoroutine("DuracionDePowerUp");

        }
    }
}