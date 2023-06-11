using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lobbycontroller : MonoBehaviour
{
    [SerializeField] private GameObject dataController;
    private DataController dataControl;
    [SerializeField] private Conversacion conversacion0;
    [SerializeField] private Conversacion conversacion1;
    [SerializeField] private Conversacion conversacion2;
    [SerializeField] private Conversacion conversacion3;
    [SerializeField] private Conversacion conversacion4;
    [SerializeField] private DialogoUI dialUI;
    [SerializeField] private Trampilla trampilla;
    public changeScene changeSc;
    public personaje player;

    void Start()
    {
        //dataController = GameObject.FindGameObjectWithTag("dataController");
        dataControl = dataController.GetComponent<DataController>();


        dataControl.ChargeData();


        switch (player.actualLvl)
        {
            case 0:
                Debug.Log("nivel 0");
                lvl0();
                break;

            case 1:
                Debug.Log("nivel 1");
                lvl1();
                break;

            case 2:
                Debug.Log("nivel 2");
                lvl2();
                break;

            case 3:
                Debug.Log("nivel 3");
                lvl3();
                break;

        }

    }

    void Update()
    {
        //TODO: meter restricciones de movimiento hacia el objeto con tag player



            switch (player.actualLvl)
            {
                case 0:
                    lvl0();
                    break;

                case 1:
                    //Debug.Log("nivel 1");
                    lvl1();
                    break;

                case 2:
                    //Debug.Log("nivel 2");
                    lvl2();
                    break;

                case 3:
                    //Debug.Log("nivel 3");
                    lvl3();
                    break;

            }

        
        
    }

    private void lvl0()
    {
        //probar bloquear al finalizar la conversación para no repetirla
        dialUI.conversacion = conversacion0;
        player.actualLvl = 0;

        if (dialUI.conversacion.finalizado)
        {
            dialUI.conversacion.desbloqueada = false;
            int opcion = -1;

            for(int i = 1; i <= dialUI.conversacion.pregunta.opciones.Length; i++)
            {
                if (dialUI.conversacion.pregunta.opciones[i].convResultante.finalizado)
                {
                    opcion = i;
                }
            }

            if(opcion > 0)
            {
                switch(opcion)
                {
                    case 1:

                        trampilla.activo = true;
                        changeSc.enabled = true;

                        break;

                    case 2:

                        lvl1();

                        break;
                }
            }

        }
        else
        {
            changeSc.enabled = false;
        }
        
        
        



    }

    private void lvl1()
    {
        //conversación antes del nivel uno
        dialUI.conversacion = conversacion1;
        player.actualLvl = 1;

        if (dialUI.conversacion.finalizado)
        {
            changeSc.enabled = true;
            changeSc.nextScene = 6;
        }
        else
        {
            changeSc.enabled = false;
        }

        
        



    }

    private void lvl2()
    {
        //conversación antes del nivel dos
        

        dialUI.conversacion = conversacion2;
    }

    private void lvl3()
    {
        //conversación antes del nivel tres
        

        dialUI.conversacion = conversacion3;
    }

}
