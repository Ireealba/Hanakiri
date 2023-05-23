using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lobbycontroller : MonoBehaviour
{
    [SerializeField] private GameObject dataController;
    private DataController dataControl;
    private int actualLvl;
    [SerializeField] private Conversacion conversacion0;
    [SerializeField] private Conversacion conversacion1;
    [SerializeField] private Conversacion conversacion2;
    [SerializeField] private Conversacion conversacion3;
    [SerializeField] private Conversacion conversacion4;
    [SerializeField] private DialogoUI dialUI;
    public bool conversacion;
    public int conversacionOp;
    [SerializeField] private Trampilla trampilla;

    void Start()
    {
        //dataController = GameObject.FindGameObjectWithTag("dataController");
        dataControl = dataController.GetComponent<DataController>();


        dataControl.ChargeData();

        actualLvl = dataControl.savedData.actualLvl;
        conversacion = false;

        switch (actualLvl)
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

            case 4:
                Debug.Log("nivel 4");
                lvl4();
                break;
        }

    }

    void Update()
    {
        //TODO: meter restricciones de movimiento hacia el objeto con tag player
        if (conversacion)
        {
            Debug.Log("Conversación hecha");

            switch (actualLvl)
            {
                case 0:
                    Debug.Log(conversacionOp);
                    switch (conversacionOp)
                    {
                        case 1:
                            trampilla.activo = true;
                            break;

                        case 2:
                            conversacion = false;
                            lvl1();
                            break;

                    }
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

                case 4:
                    Debug.Log("nivel 4");
                    lvl4();
                    break;
            }

        }
        
    }

    private void lvl0()
    {
        //conversación tutorial y da a elegir entre tutorial o no si tutorial abrir trampilla
        
        
        dialUI.conversacion = conversacion0;

        

    }

    private void lvl1()
    {
        //conversación antes del nivel uno
        

        dialUI.conversacion = conversacion1;
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

    private void lvl4()
    {
        //conversación antes del nivel cuatro
        

        dialUI.conversacion = conversacion4;
    }
}
