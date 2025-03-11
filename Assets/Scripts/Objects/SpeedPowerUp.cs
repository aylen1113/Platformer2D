using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedPowerUp : Powerups
{
    private PlayerMovement player;

    protected override void aplicar()
    {
        if (efectoActivado == true)
            jugador.GetComponent<PlayerMovement>().moveSpeed += valorAgregado;
        else
            jugador.GetComponent<PlayerMovement>().moveSpeed -= valorAgregado;
    }
}

