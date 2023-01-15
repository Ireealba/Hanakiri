using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDialogos : MonoBehaviour
{
    private Animator anim;
    private Queue<string> colaDialogos;
    Textos texto;
    [SerializeField] TextMeshProUGUI textoPantalla;

    bool activado = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        colaDialogos = new Queue<string>();
    }

    void Update()
    {
        if(activado == true && Input.GetKeyDown("e"))
        {
            SiguienteFrase();
        }
    }

    public void ActivarCartel(Textos textoObjeto)
    {
        anim.SetBool("Cartel", true);
        texto = textoObjeto;
    }

    public void ActivaTexto()
    {
        colaDialogos.Clear();
        foreach(string textoGuardar in texto.arrayTextos)
        {
            colaDialogos.Enqueue(textoGuardar);
        }
        activado = true;
        SiguienteFrase();
    }

    public void SiguienteFrase()
    {
        if(colaDialogos.Count == 0)
        {
            textoPantalla.text = "";
            CierraCartel();
            return;
        }

        string fraseActual = colaDialogos.Dequeue();
        textoPantalla.text = fraseActual;
    }

    IEnumerator MostrarCaracteres(string textoAMostrar)
    {
        textoPantalla.text = "";
        foreach(char caracter in textoAMostrar.ToCharArray())
        {
            textoPantalla.text += caracter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void CierraCartel()
    {
        anim.SetBool("Cartel", false);
    }
}
