using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    //public GameObject plantPrefab;
    //public GameObject rabbitPrefab;
    //public GameObject duckPrefab;

    //public GameObject applePrefab;
    //public GameObject orangePrefab;
    //public GameObject strawberryPrefab;

    //public Transform[] spawnPoints; // Array to hold spawn points
    //public float spawnDistance = 5f; // Distance at which enemies spawn near the player
    public float navMeshSampleRange = 1.0f; // Range to find a valid NavMesh position
    //public float spawnInterval = 10f; // Time interval between spawns

    public Text coinText;
    public int counter;

    private PlayerHealth player;

    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();


        //foreach (Transform spawnPoint in spawnPoints)
        //{
        //    StartCoroutine(SpawnEnemyAtPoint(spawnPoint));
        //}


    }

    //private IEnumerator SpawnEnemyAtPoint(Transform spawnPoint)
    //{
    //    while (true)
    //    {
    //        float distanceToPlayer = Vector3.Distance(spawnPoint.position, player.transform.position);
    //        if (distanceToPlayer <= spawnDistance)
    //        {
    //            Vector3? validPosition = GetNavMeshPosition(spawnPoint.position);
    //            if (validPosition.HasValue)
    //            {
    //                SpawnRandomEnemy(validPosition.Value);
    //            }
    //        }

    //        yield return new WaitForSeconds(spawnInterval); // Wait for the interval before checking again
    //    }
    //}

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

    //private void SpawnRandomEnemy(Vector3 spawnPosition)
    //{
    //    //GameObject[] enemyPrefabs = new GameObject[] { plantPrefab, rabbitPrefab, duckPrefab };
    //    //GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

    //    //Enemy enemy = Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity).GetComponent<Enemy>();
    //    enemy.Attack(player);
    //}

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
