using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    public static bool onWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Suelo")
        {
            onWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Suelo")
        {
            onWall = true;
        }
    }
}
