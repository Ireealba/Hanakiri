using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lobbycontroller : MonoBehaviour
{
    private GameObject dataController;
    private DataController dataControl;
    private int actualLvl;

    void Start()
    {
        dataController = GameObject.FindGameObjectWithTag("dataController");
        dataControl = dataController.GetComponent<DataController>();

        if(File.Exists(Application.dataPath + "/gamesaves/gamedata.json"))
        {
            dataControl.ChargeData();

            actualLvl = dataControl.savedData.actualLvl;
        }
        else
        {
            actualLvl = 0;
        }

        switch(actualLvl)
        {
            case 0:
                lvl0();
                break;
        }
    }

    void Update()
    {
        //TODO: meter restricciones de movimiento hacia el objeto con tag player
        
    }

    private void lvl0()
    {

    }
}
