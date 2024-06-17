using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;


public class Coin : Collectible
{
    public int value;


    public override void Collect()
    {
        // Aumentar el contador de monedas del jugador
        //GameManager.instance.AddCoins(value);

    }
}

