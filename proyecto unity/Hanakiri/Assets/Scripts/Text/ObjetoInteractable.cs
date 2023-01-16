using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;
    public static bool dialogo = false;

    private void Update()
    {
        if (Input.GetKeyDown("e") && personaje.accion == true)
        {
          FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
            dialogo = true;
        }
    }

}
