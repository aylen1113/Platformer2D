using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
 

   
    public GameObject birdPrefab;
    public GameObject plantPrefab;
    public GameObject rabbitPrefab;

 
    public GameObject applePrefab;
    public GameObject orangePrefab;
    public GameObject strawberryPrefab;


    public Text coinText;
    public int counter;

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

    public void CoinText(int add)
    {
        counter += add;
        coinText.text = "COINS: " + counter ; 

    }

    public void OnEnable()
    {
        Coin.coinEvent += CoinText;

    }
    public void OnDisable()
    {
        Coin.coinEvent -= CoinText;

    }

}
