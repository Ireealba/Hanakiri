using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;

    private void Update()
    {
        if (Input.GetKeyDown("E"))
        {
          FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
        }
    }

}
