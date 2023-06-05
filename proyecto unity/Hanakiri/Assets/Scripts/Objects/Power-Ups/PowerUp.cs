using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    int velocidad;
    int salto;
    int vida;
    int ataque;
    int monedas;
    int timer;

    bool collected;
    bool used;

    float usingTime;
    
   
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
    }
}
