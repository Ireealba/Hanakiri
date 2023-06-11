using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    public Conversacion conversacion;    //conversacion actual mostrada
    [SerializeField]
    private float textSpeed = 20;

    [SerializeField]
    private GameObject convContainer;
    [SerializeField]
    private GameObject pregContainer;

    [SerializeField]
    private Image speakIm;
    [SerializeField]
    private TextMeshProUGUI convText;

    private AudioSource audioSource;

    public int localIn = 1;              //recorre cada dialogo dentro de la conversacion actual, lo mismo que dialLocalIn en DialogueSpeaker 
                                         //solo que este adopta el valor en base al que tenga puesto el Dialogue Speaker en el momento de hablar

    [SerializeField] private Lobbycontroller lobby;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        convContainer.SetActive(true);
        pregContainer.SetActive(false);

    }

    /*
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            ActualizarTextos(1);
        }
    }
    */

    public void ActualizarTextos( int comportamiento)
    {
        convContainer.SetActive(true);
        pregContainer.SetActive(false);

        switch (comportamiento)
        {
            //retroceder con el texto
            case -1:
                if (localIn > 0)
                {
                    //print("Dialogo anterior");
                    localIn--;
                    StopAllCoroutines();
                    StartCoroutine(EscribirTexto());
                    //convText.text = conversacion.dialogos[localIn].dialogo;
                    speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                    if (conversacion.dialogos[localIn].sonido != null)
                    {
                        audioSource.Stop();
                        var audio = conversacion.dialogos[localIn].sonido;
                        audioSource.PlayOneShot(audio);
                    }

                }

                DialogoManager.speakerActual.dialLocalIn = localIn;
                break;

            //no avanzar con el texto
            case 0:
                //print("Dialogo actualizado");

                //nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                StopAllCoroutines();
                StartCoroutine(EscribirTexto());
                //convText.text = cnversacion.dialogos[localIn].dialogo;
                speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                if (conversacion.dialogos[localIn].sonido != null)
                {
                    audioSource.Stop();
                    var audio = conversacion.dialogos[localIn].sonido;
                    audioSource.PlayOneShot(audio);
                }

                break;

            //avanzar con el texto

            case 1:
                //el -1 es para evitar que se salga del index del array dialogos

                if(localIn < conversacion.dialogos.Length - 1)
                {
                    //print("Dialogo siguiente");
                    localIn++;
                    //nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                    StopAllCoroutines();
                    StartCoroutine(EscribirTexto());
                    //convText.text = conversacion.dialogos[localIn].dialogo;
                    speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                    if (conversacion.dialogos[localIn].sonido != null)
                    {
                        audioSource.Stop();
                        var audio = conversacion.dialogos[localIn].sonido;
                        audioSource.PlayOneShot(audio);
                    }
                }
                else
                {
                    print("Dialogo terminado");
                    localIn = 0;
                    DialogoManager.speakerActual.dialLocalIn = 0;
                    conversacion.finalizado = true;

                    if(conversacion.pregunta != null)
                    {
                        convContainer.SetActive(false);
                        pregContainer.SetActive(true);
                        var preg = conversacion.pregunta;
                        DialogoManager.instance.controladorPreguntas.ActivarBotones(preg.opciones.Length, preg.pregunta, preg.opciones, preg.personaje);

                        return;
                    }


                    DialogoManager.instance.MostrarUI(false);
                    
                }

                DialogoManager.speakerActual.dialLocalIn = localIn;

                break;

            default:
                Debug.LogWarning("Estas pasando un valor no admitido(solo se aceptan estos valores: -1, 0, 1");
                break;
        }

        IEnumerator EscribirTexto()
        {
            convText.maxVisibleCharacters = 0;
            convText.text = conversacion.dialogos[localIn].dialogo;
            convText.richText = true;

            for(int i = 0; i < conversacion.dialogos[localIn].dialogo.ToCharArray().Length; i++)
            {
                convText.maxVisibleCharacters++;
                yield return new WaitForSeconds(1f / textSpeed);
            }
        }

    }
}
