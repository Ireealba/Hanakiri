using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;
    public bool dialogue = false;
    [SerializeField] private DialogueSpeaker dialSp;
    [SerializeField] private DialogoUI dialUI;

    private void Update()
    {
        if (Input.GetKeyDown("e") && personaje.accion == true)
        {          
            if (!dialogue)
            {
                dialogue = true;
                dialSp.Conversar();
            }
            else
            {
                dialUI.ActualizarTextos(1);
            }
        }
    }

}
