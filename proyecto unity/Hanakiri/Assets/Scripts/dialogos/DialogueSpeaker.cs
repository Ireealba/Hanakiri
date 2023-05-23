using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueSpeaker : MonoBehaviour
{
    public List<Conversacion> conversacionesDisponibles = new List<Conversacion>();

    [SerializeField]
    private int indexDeConversaciones = 0;

    public int dialLocalIn = 0;
    public bool dialogue = false;

    private void Start()
    {
        indexDeConversaciones = 0;
        dialLocalIn = 0;
        dialogue = false;

        foreach(var conv in conversacionesDisponibles)
        {
            conv.finalizado = false;
            var preg = conv.pregunta;
            if(preg != null)
            {
                foreach(var opcion in preg.opciones)
                {
                    opcion.convResultante.finalizado = false;
                }
            }
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetButtonUp("Interact"))
        {
            if(!dialogue)
            {
                dialogue = true;
                Conversar();
            }
            else
            {
                DialogoManager.instance.siguienteDialogo();
            }
        }

        if(collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
        {
            DialogoManager.instance.cambiarEstadoDeReusable(conversacionesDisponibles[indexDeConversaciones], !conversacionesDisponibles[indexDeConversaciones].reUsar);
        }
    }
    */

    public void Conversar()
    {
        if(indexDeConversaciones <= conversacionesDisponibles.Count - 1)
        {
            if (conversacionesDisponibles[indexDeConversaciones].desbloqueada)
            {
                if (conversacionesDisponibles[indexDeConversaciones].finalizado)
                {
                    if (ActualizarConversacion())
                    {
                        DialogoManager.instance.MostrarUI(true);
                        DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones], this);
                    }

                    DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones], this);
                    return;
                }

                DialogoManager.instance.MostrarUI(true);
                DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones], this);
            }
            else
            {
                Debug.LogWarning("La conversacion esta bloqueada");
                DialogoManager.instance.MostrarUI(false);
            }
        }
        else
        {
            //ya use todas las conversaciones disponibles
            print("Fin del dialogo");
            DialogoManager.instance.MostrarUI(false);
        }
    }

    bool ActualizarConversacion()
    {
        if (!conversacionesDisponibles[indexDeConversaciones].reUsar)
        {
            if(indexDeConversaciones < conversacionesDisponibles.Count - 1)
            {
                indexDeConversaciones++;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

}
