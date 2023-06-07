using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{

    public PowerUp[] powerUps = new PowerUp[9];

    int timer;
    
   
    void agregarPowerUp()
    {
        // personaje.velocidad+=velocidad

    }

    void quitarPowerUp()
    {
        // personaje.velocidad-=velocidad
    }

    void Update()
    {
        /*
        if(collected && !used)
        {
            agregarPowerUp();
            used = true;
            // El timer empieza
        }

        if(timer==usingTime)
        {
            quitarPowerUp();
        }
        */
    }
}
