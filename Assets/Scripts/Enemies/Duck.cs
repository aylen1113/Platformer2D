using System.Collections;
using UnityEngine;

public class Duck : Enemy

{
    [SerializeField] private float flyHeight = 5f; // Altura a la que el pato vuela antes de atacar
    [SerializeField] private float diveSpeed = 7f; // Velocidad de la picada
    [SerializeField] private float returnSpeed = 3f; // Velocidad de regreso a su posición inicial
    [SerializeField] private float attackCooldown = 4f; // Tiempo entre ataques
    [SerializeField] private int damage = 15; // Daño al jugador

    private Vector3 originalPosition; // Posición inicial del pato
    private Transform playerTransform;
    private bool isAttacking = false; // Evita que realice múltiples ataques a la vez

    private float lastAttackTime = 0f;

    public override void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        originalPosition = transform.position; // Guarda la posición inicial
    }

    public override void Update()
    {
        base.Update();

        CheckGround();

        if (!isGrounded)
        {
            agent.isStopped = true;
        }
        else if (isChasing)
        {
            agent.isStopped = false;
        }

        // Inicia el ataque si el cooldown ha pasado
        if (!isAttacking && Time.time >= lastAttackTime + attackCooldown)
        {
            StartCoroutine(DiveAttack());
        }
    }

    private IEnumerator DiveAttack()
    {
        isAttacking = true;

        // Paso 1: Elevarse hacia arriba
        Vector3 flyPosition = originalPosition + Vector3.up * flyHeight;
        yield return MoveToPosition(flyPosition, returnSpeed);

        // Paso 2: Realizar picada hacia el jugador
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position;
            yield return MoveToPosition(targetPosition, diveSpeed);

            // Verificar colisión con el jugador para aplicar daño
            if (Vector3.Distance(transform.position, playerTransform.position) < 1f)
            {
                PlayerHealth player = playerTransform.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }
        }

        // Paso 3: Regresar a la posición inicial
        yield return MoveToPosition(originalPosition, returnSpeed);

        // Finalizar ataque y reiniciar el cooldown
        lastAttackTime = Time.time;
        isAttacking = false;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float speed)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}

