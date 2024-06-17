using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;

   
    public GameObject birdPrefab;
    public GameObject plantPrefab;
    public GameObject rabbitPrefab;

 
    public GameObject applePrefab;
    public GameObject orangePrefab;
    public GameObject strawberryPrefab;



    void Start()
    {
        PlayerHealth player = FindObjectOfType<PlayerHealth>();


        Enemy[] enemies = new Enemy[]
        {
            Instantiate(birdPrefab).GetComponent<Bird>(),
            Instantiate(plantPrefab).GetComponent<Plant>(),
            Instantiate(rabbitPrefab).GetComponent<Rabbit>()
        };

        foreach (Enemy enemy in enemies)
        {
            enemy.Attack(player);
        }

      
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
    }

    public void AddScore()
    {
        // Add score logic here
    }
}
