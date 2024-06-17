using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : Collectible
{
    public int extraLives = 1;

 
    public override void Collect()
    {
        // Aumentar el número de vidas del jugador
        //GameManager.instance.AddLives(extraLives);

    }
}