using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoManager : MonoBehaviour
{
    public static DialogoManager instance { get; private set; }
    public static DialogueSpeaker speakerActual;
    [SerializeField]
    private DialogoUI dialUI;
    //[SerializeField] private GameObject player;

    [SerializeField] private ObjetoInteractable obIn;

    public ControladorPreguntas controladorPreguntas;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }

        dialUI = FindObjectOfType<DialogoUI>();

        controladorPreguntas = FindObjectOfType<ControladorPreguntas>();
    }

    private void Start()
    {
        MostrarUI(false);

        //player.GetComponent<DialogueSpeaker>().Conversar();
    }

    public void MostrarUI(bool mostrar)
    {
        dialUI.gameObject.SetActive(mostrar);

        if (!mostrar)
        {
            dialUI.localIn = 0;
            obIn.dialogue = false;
            
            //TODO: devolver movimiento
        }
        else
        {
            obIn.dialogue = true;
            //TODO: restringir movimiento
        }
    }

    public void SetConversacion(Conversacion conv, DialogueSpeaker speaker)
    {
        if(speaker != null)
        {
            speakerActual = speaker;
        }
        else
        {
            //en caso de ser speaker null quiere decir que vengo de una pregunta 
            //por lo que reseteo el localin para recorrer toda la nueva conersacion producto de la respuesta elegida
            dialUI.conversacion = conv;
            dialUI.localIn = 0;
            dialUI.ActualizarTextos(0);
        }

        if(conv.finalizado && !conv.reUsar)
        {
            dialUI.conversacion = conv;
            dialUI.localIn = conv.dialogos.Length;
            dialUI.ActualizarTextos(1);
        }
        else
        {
            dialUI.conversacion = conv;
            dialUI.localIn = speakerActual.dialLocalIn;
            dialUI.ActualizarTextos(0);
        }
    }

    public void cambiarEstadoDeReusable(Conversacion conv, bool estadoDeseado)
    {
        conv.reUsar = estadoDeseado;
    }

    //funcion a llamar para desbloquear x conversacion
    public void BloqueoYDesbloqueoDeConversacion(Conversacion conv, bool desbloquear)
    {
        conv.desbloqueada = desbloquear;
    }
}
