using System.Collections;
using UnityEngine;

public abstract class Powerups : MonoBehaviour, ICollectable
{
    [SerializeField] protected float duracionDeEfecto;
    [SerializeField] protected int valorAgregado;
    [SerializeField] public bool efectoActivado;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected GameObject jugador;
    protected PlayerMovement playerMovement;

    protected void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            playerMovement = jugador.GetComponent<PlayerMovement>();
        }
        efectoActivado = false;
    }

    protected abstract void aplicar();

    protected IEnumerator DuracionDePowerUp()
    {
        if (playerMovement == null) yield break;

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
        if (other.gameObject.CompareTag("Player") && !efectoActivado)
        {
            spriteRenderer.enabled = false;
            StartCoroutine(DuracionDePowerUp());
        }
    }
}
