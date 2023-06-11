using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorPreguntas : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPref;
    [SerializeField]
    private TextMeshProUGUI pregText;
    [SerializeField]
    private Transform opcionesContainer;
    [SerializeField]
    private Image speakerIm;
    private List<Button> poolButtons = new List<Button>();
    [SerializeField] private Lobbycontroller lobby;

    private void Start()
    {
        
    }

    public void ActivarBotones(int cantidad, string title, Opciones[] opciones, Personaje pers)
    {
        speakerIm.sprite = pers.imagen;
        pregText.text = title;
        if(poolButtons.Count >= cantidad)
        {
            for(int i = 0; i < poolButtons.Count; i++)
            {
                if(i < cantidad)
                {
                    poolButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = opciones[i].opcion;
                    poolButtons[i].onClick.RemoveAllListeners();
                    Conversacion co = opciones[i].convResultante;
                    int opcion = i + 1;
                    poolButtons[i].onClick.AddListener(() => DarFuncionABotones(co, opcion) );
                    poolButtons[i].gameObject.SetActive(true);
                }
                else
                {
                    poolButtons[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            int cantidadRestante = (cantidad - poolButtons.Count);
            for(int i = 0; i < cantidadRestante; i++)
            {
                var newButton = Instantiate(buttonPref, opcionesContainer).GetComponent<Button>();
                newButton.gameObject.SetActive(true);
                poolButtons.Add(newButton);
            }
            ActivarBotones(cantidad, title, opciones, pers);
        }
    }

    public void DarFuncionABotones(Conversacion conv, int nOpcion)
    {
        lobby.opcionPreg = nOpcion;
        Debug.Log("opcion de boton: " + nOpcion);
        DialogoManager.instance.SetConversacion(conv, null);
    }
}
