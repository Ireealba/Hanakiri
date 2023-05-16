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

            case 1:
                lvl1();
                break;

            case 2:
                lvl2();
                break;

            case 3:
                lvl3();
                break;

            case 4:
                lvl4();
                break;
        }
    }

    void Update()
    {
        //TODO: meter restricciones de movimiento hacia el objeto con tag player
        
    }

    private void lvl0()
    {
        //conversaci�n tutorial y da a elegir entre tutorial o no si tutorial abrir trampilla
        /*
         * S: Bienvenida Hana, te estaba esperando
         * H: �C�mo sabes como me llamo?
         * S: Te conozco de siempre, era cuesti�n de tiempo que acabaras viniendo aqu�, al fin y al cabo es tu desti...
         * S: Espera. Te parece raro que sepa c�mo te llamas pero �no te parece raro que sea una calavera flotante?
         * H: Nah, ya no me sorprende nada.
         * S: Estos j�venes...
         * H: Contin�a hablando, �ibas a decir algo de mi destino?
         * S: Ah, s�. Debes de ayudar a salvar el m�s all� de las garras de un ente maligno. T�, Hana, eres la elegida.
         * H: Qu� es esto ahora, �el zelda?
         * S: Hana, por favor, que nos lo tiran por copyright.
         * S: El caso es que necesitamos tu ayuda.
         * H: No estoy muy segura, �qu� tendr�a que hacer?
         * S: Pues ir�as por los distintos umbrales, salvando las almas de los esp�ritus con ayuda de un arma m�gica...
         * H: �Has dicho arma m�gica?�Hablas de una espada maldita que usa la fuerza vital del portador o algo m�s del estilo un arma con alma y consciencia propias?
         * S: Pues... Esas ideas hubieran estado bastante bien, s�. Pero solo es una guada�a, no es nada del otro mundo...
         * H: �Solo una guada�a?�Ni poderes, ni almas, ni luces?
         * S: No. Lo �nico que tiene de especial es que es capaz de liberar las almas de los esp�ritusinfectados...
         * H: Y ahora me vas a decir que solo le hace caso a la persona elegida, �verdad?
         * S: Pues... s�
         * H: Me lo ve�a venir. Pero en fin, lo intentar�. De todas formas no tengo nada mejor que hacer.
         * S: Est� bien. Te hago entrega de la guada�a maestra.
         * H: Qu� originales...
         * S: Bueno, antes de empezar con tu misi�n me gustar�a pedirte un favor.
         * H: Dispara.
         * S: Ver�s, dej� olvidadas las llaves de la puerta al final del s�tano, �te importar�a ir a por ellas?
         * H: 1-Est� bien, qu� remedio(hacer tutorial) 2-Illo, haz magia de esa rara tuya y hazlo t�(saltar tutorial)
         * --------------------------------Si la respuesta fue 1----------------------------------------------
         * S: Muchas gracias, entra por la trampilla que hay detr�s tuya
         * H: Pero si no hab�a ninguna trampilla. Ah, vale, cosas raras de magia.
         * --------------------------------Si la respuesta fue 2----------------------------------------------
         * S: Est� bien, de todas formas no necesitaba esas llaves
         * H: �
         */

    }

    private void lvl1()
    {
        //conversaci�n antes del nivel uno
    }

    private void lvl2()
    {
        //conversaci�n antes del nivel dos
    }

    private void lvl3()
    {
        //conversaci�n antes del nivel tres
    }

    private void lvl4()
    {
        //conversaci�n antes del nivel cuatro
    }
}
