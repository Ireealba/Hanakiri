using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprarObjeto : MonoBehaviour
{
    public ShopController sc;
    public int objeto;
    public int precio;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sc.Comprar(objeto, precio);
            }
        }
    }

}
