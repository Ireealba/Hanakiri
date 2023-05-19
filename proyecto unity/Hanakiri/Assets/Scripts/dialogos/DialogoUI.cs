using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    public Conversacion conversacion;    //conversacion actual mostrada
    [SerializeField]
    private float textSpeed = 10;


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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        convContainer.SetActive(true);
        pregContainer.SetActive(false);

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            ActualizarTextos(1);
        }
    }

    public void ActualizarTextos( int comportamiento)
    {
        convContainer.SetActive(true);
        pregContainer.SetActive(false);

/*
        switch (comportamiento)
        {
            //retroceder con el texto

            case -1:
                if(localIn > 0)
                {
                    print("Dialogo anterior");
                }

        }
*/
    }
}
