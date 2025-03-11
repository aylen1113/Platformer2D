using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : Powerups
{
    private PlayerMovement player;

    protected override void aplicar()
    {
        if (efectoActivado == true)

            jugador.GetComponent<PlayerMovement>().jumpForce += valorAgregado;
        else
            jugador.GetComponent<PlayerMovement>().jumpForce -= valorAgregado;
    }
}


