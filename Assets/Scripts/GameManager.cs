using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    //public GameObject birdPrefab;
    public GameObject plantPrefab;
    public GameObject rabbitPrefab;

    public GameObject applePrefab;
    public GameObject orangePrefab;
    public GameObject strawberryPrefab;

    public Transform[] spawnPoints; // Array to hold spawn points
    public float spawnDistance = 5f; // Distance at which enemies spawn near the player
    public float navMeshSampleRange = 1.0f; // Range to find a valid NavMesh position

    public Text coinText;
    public int counter;

    private PlayerHealth player;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();

        // Initialize power-ups (this runs once at the start)
        PowerUp[] powerUps = new PowerUp[]
        {
            Instantiate(applePrefab).GetComponent<Apple>(),
            Instantiate(orangePrefab).GetComponent<Orange>(),
            Instantiate(strawberryPrefab).GetComponent<Strawberry>()
        };

        foreach (PowerUp powerUp in powerUps)
        {
            powerUp.ApplyPowerup();
        }

        // Start checking for player proximity to spawn points
        StartCoroutine(CheckSpawnPoints());
    }

    private IEnumerator CheckSpawnPoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Check every second

            foreach (Transform spawnPoint in spawnPoints)
            {
                float distanceToPlayer = Vector3.Distance(spawnPoint.position, player.transform.position);
                if (distanceToPlayer <= spawnDistance)
                {
                    Vector3? validPosition = GetNavMeshPosition(spawnPoint.position);
                    if (validPosition.HasValue)
                    {
                        SpawnEnemiesAtPoint(validPosition.Value);
                        spawnPoint.gameObject.SetActive(false); // Deactivate the spawn point after spawning
                    }
                }
            }
        }
    }

    private Vector3? GetNavMeshPosition(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, navMeshSampleRange, NavMesh.AllAreas))
        {
            return hit.position; // Return the valid NavMesh position
        }
        else
        {
            Debug.LogWarning($"No valid NavMesh position near {position}");
            return null; // No valid NavMesh position found
        }
    }

    private void SpawnEnemiesAtPoint(Vector3 spawnPosition)
    {
        Enemy[] enemies = new Enemy[]
        {
            //Instantiate(birdPrefab, spawnPosition, Quaternion.identity).GetComponent<Bird>(),
            Instantiate(plantPrefab, spawnPosition, Quaternion.identity).GetComponent<Plant>(),
            Instantiate(rabbitPrefab, spawnPosition, Quaternion.identity).GetComponent<Rabbit>()
        };

        foreach (Enemy enemy in enemies)
        {
            enemy.Attack(player);
        }
    }

    public void CoinText(int add)
    {
        counter += add;
        coinText.text = "COINS: " + counter;
    }

    private void OnEnable()
    {
        Coin.coinEvent += CoinText;
    }

    private void OnDisable()
    {
        Coin.coinEvent -= CoinText;
    }
}
