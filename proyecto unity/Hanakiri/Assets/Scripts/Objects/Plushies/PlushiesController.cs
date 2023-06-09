using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushiesController : MonoBehaviour
{
    public Coleccionable[] plushies;
    public coleccionablesController cc;

    private bool charged;

    void Start()
    {
        cc = FindObjectOfType<coleccionablesController>();

        if(cc != null )
        {
            cc.ChargeData();
            Debug.Log("coleccionables cargados");
            charged = true;
        }
        else
        {
            Debug.Log("no se encontro ningun tipo cc");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!charged)
        {
            cc.ChargeData();
        }
    }

    public void agregarColecionable(GameObject plushie)
    {
        Debug.Log(plushie.name);
        int index = -1;

        for (int i = 0; i < plushies.Length; i++)//no entra al for :(
        {
            Debug.Log(plushies[i].name);
            if (plushie.name == plushies[i].name)
            {
                index = i;
                Debug.Log("agregado: " + plushie.name);
            }

            if(index >= 0 && index < plushies.Length)
            {
                plushies[index].owned = true;

                cc.SaveData();
                charged = false;
            }
            else
            {
                Debug.Log("index erroneo");
            }
        }
    }
}
