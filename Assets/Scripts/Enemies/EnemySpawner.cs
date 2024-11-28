using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public string name;
        public GameObject prefab; // The enemy prefab
        public int poolSize; // Number of enemies to pool
    }

    public EnemyType[] enemyTypes; // List of different enemy types
    public Transform[] spawnPoints; // Spawn points in the scene
    public float spawnInterval = 3f; // Time interval between spawns

    private Dictionary<string, Queue<GameObject>> enemyPools;

    private void Start()
    {
        // Initialize enemy pools
        enemyPools = new Dictionary<string, Queue<GameObject>>();

        foreach (var enemyType in enemyTypes)
        {
            Queue<GameObject> enemyPool = new Queue<GameObject>();

            for (int i = 0; i < enemyType.poolSize; i++)
            {
                GameObject enemy = Instantiate(enemyType.prefab);
                enemy.SetActive(false);
                enemyPool.Enqueue(enemy);
            }

            enemyPools.Add(enemyType.name, enemyPool);
        }

        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Pick a random enemy type and spawn point
            var randomEnemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
            var randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            SpawnEnemy(randomEnemyType.name, randomSpawnPoint.position);
        }
    }

    private void SpawnEnemy(string enemyTypeName, Vector3 position)
    {
        if (!enemyPools.ContainsKey(enemyTypeName))
        {
            Debug.LogError($"Enemy type {enemyTypeName} not found!");
            return;
        }

        var enemyPool = enemyPools[enemyTypeName];
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.transform.position = position;
            enemy.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"No enemies left in pool for {enemyTypeName}");
        }
    }

    public void ReturnEnemyToPool(GameObject enemy, string enemyTypeName)
    {
        if (!enemyPools.ContainsKey(enemyTypeName))
        {
            Debug.LogError($"Enemy type {enemyTypeName} not found!");
            return;
        }

        enemy.SetActive(false);
        enemyPools[enemyTypeName].Enqueue(enemy);
    }
}
