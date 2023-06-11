using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Lobbycontroller : MonoBehaviour
{
    [SerializeField] private GameObject dataController;
    private DataController dataControl;
    [SerializeField] private Conversacion conversacion;
    [SerializeField] private GameObject dialUIobj;
    private DialogoUI dialUI;
    [SerializeField] private Trampilla trampilla;
    public GameObject[] changeSc;
    public personaje player;
    public int opcionPreg;
    private bool first0;
    private bool first1;
    private bool first2;
    private bool first3;
    private bool prevLvl;

    void Start()
    {
        //dataController = GameObject.FindGameObjectWithTag("dataController");
        dataControl = dataController.GetComponent<DataController>();
        prevLvl = false;


        dataControl.ChargeData();
        dialUIobj.SetActive(true);
        dialUI = dialUIobj.GetComponent<DialogoUI>();

        switch (player.actualLvl)
        {
            case 0:
                Debug.Log("nivel 0");
                first0 = true;
                first1 = false;
                first2 = false;
                first3 = false;
                dialUI.conversacion.desbloqueada = true;
                dialUI.conversacion.finalizado = false;

                lvl0();
                break;

            case 1:
                Debug.Log("nivel 1");
                first0 = false;
                first1 = true;
                first2 = false;
                first3 = false;
                dialUI.conversacion.desbloqueada = true;
                dialUI.conversacion.finalizado = false;

                lvl1();
                break;

            case 2:
                Debug.Log("nivel 2");
                first0 = false;
                first1 = false;
                first2 = true;
                first3 = false;
                dialUI.conversacion.desbloqueada = true;
                dialUI.conversacion.finalizado = false;

                lvl2();
                break;

            case 3:
                Debug.Log("nivel 3");
                first0 = false;
                first1 = false;
                first2 = false;
                first3 = true;
                dialUI.conversacion.desbloqueada = true;
                dialUI.conversacion.finalizado = false;

                lvl3();
                break;

        }

    }

    void Update()
    {

            switch (player.actualLvl)
            {
                case 0:
                if (first0)
                {
                    lvl0();
                }
                else
                {
                    dialUIobj.SetActive(true);
                    dialUI = dialUIobj.GetComponent<DialogoUI>();
                    first0 = true;
                    first1 = false;
                    first2 = false;
                    first3 = false;
                    dialUI.conversacion.desbloqueada = true;
                    dialUI.conversacion.finalizado = false;
                    player.actualLvl = 0;

                    lvl0();
                }
                    
                    break;

                case 1:
                
                if (first1 && prevLvl || first1)
                {
                    lvl1();
                }
                else
                {
                    Debug.Log("nivel 1");
                    first0 = false;
                    first1 = true;
                    first2 = false;
                    first3 = false;
                    dialUI.conversacion.desbloqueada = true;
                    dialUI.conversacion.finalizado = false;
                    player.actualLvl = 1;

                    lvl1();
                }
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

        if (dialUI.conversacion.finalizado)
        {
            dialUI.conversacion.desbloqueada = false;

            Debug.Log("opcion elegida: " + opcionPreg);
            if (opcionPreg > 0)
            {
                switch (opcionPreg)
                {
                    case 1:

                        Debug.Log("acceso a trampilla");
                        trampilla.activo = true;
                        player.actualLvl = 0;
                        changeSc[0].SetActive(true);
                        changeSc[1].SetActive(false);

                        break;

                    case 2:
                        Debug.Log("acceso a tienda");
                        first0 = false;
                        first1 = true;
                        prevLvl = true;
                        player.actualLvl = 1;

                        break;

                    default:
                        Debug.Log("opcion no valida");
                        break;
                }
            }

        }
        else
        {
            changeSc[0].SetActive(false);
            changeSc[1].SetActive(false);
        }
        
        
        



    }

    private void lvl1()
    {
        //conversación antes del nivel uno
        //dialUI.conversacion = conversacion1;

        if(prevLvl)
        {
            if(!dialUI.isActiveAndEnabled)
            {
                changeSc[0].SetActive(false);
                changeSc[1].SetActive(true);
            }
            else
            {
                changeSc[0].SetActive(false);
                changeSc[1].SetActive(false);
            }
        }
        else
        {
            if (dialUI.conversacion.finalizado)
            {
                changeSc[0].SetActive(false);
                changeSc[1].SetActive(true);
            }
            else
            {
                changeSc[0].SetActive(false);
                changeSc[1].SetActive(false);
            }
        }

        
        



    }

    private void lvl2()
    {
        //conversación antes del nivel dos
        

        //dialUI.conversacion = conversacion2;
    }

    private void lvl3()
    {
        //conversación antes del nivel tres
        

        //dialUI.conversacion = conversacion3;
    }

}
