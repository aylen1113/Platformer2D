using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject pigBossPrefab; 
    public Transform spawnPoint; 
    private bool bossSpawned = false;
    public int coinsToSpawnBoss = 10; 
    private int currentCoins = 0; 

    void Start()
    {
        Coin.coinEvent += HandleCoinCollected;
    }

    void OnDestroy()
    {
        Coin.coinEvent -= HandleCoinCollected;
    }

    private void HandleCoinCollected(int add)
    {
        currentCoins += add;
        if (currentCoins >= coinsToSpawnBoss && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        bossSpawned = true;
        Instantiate(pigBossPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("boss spawned");
    }
}
