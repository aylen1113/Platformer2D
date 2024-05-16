using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;
    void Start()
    {
       
        Enemy[] enemies = new Enemy[]
        {
            new Bird(),
            new Plant(),
            new Rabbit(),
   
        };

  
        foreach (Enemy enemy in enemies)
        {
            enemy.Attack();
        }

        PowerUp[] powerUps = new PowerUp[]
    {
            new Apple(),
            new Orange(),
            new Strawberry()
    };

        // Iterar sobre los power-ups y aplicar sus efectos
        foreach (PowerUp powerUp in powerUps)
        {
            powerUp.ApplyPowerup();
        }
    }
    public void AddScore()
    {
        //sumar puntaje al conseguir monedas
    }
}
    


