using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject pigBossPrefab; // Prefab del PigBoss
    public Transform spawnPoint; // Punto de aparici�n del jefe
    private bool bossSpawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        bossSpawned = true;

        // Instanciar al jefe en el punto de aparici�n
        Instantiate(pigBossPrefab, spawnPoint.position, Quaternion.identity);

        Debug.Log("Pig Boss has spawned!");
    }
}
