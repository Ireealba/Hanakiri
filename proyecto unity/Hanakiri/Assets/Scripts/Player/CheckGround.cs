using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Suelo")
        {
            isGrounded = true;
        }
        
        if(collision.tag == "cuadro de accion")
        {
            personaje.iconoaccion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Suelo")
        {
            isGrounded = true;
        }

        if (collision.tag == "cuadro de accion")
        {
            personaje.iconoaccion = false;
        }
    }
}
