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
        //conversación tutorial y da a elegir entre tutorial o no si tutorial abrir trampilla
        /*
         * S: Bienvenida Hana, te estaba esperando
         * H: ¿Cómo sabes como me llamo?
         * S: Te conozco de siempre, era cuestión de tiempo que acabaras viniendo aquí, al fin y al cabo es tu desti...
         * S: Espera. Te parece raro que sepa cómo te llamas pero ¿no te parece raro que sea una calavera flotante?
         * H: Nah, ya no me sorprende nada.
         * S: Estos jóvenes...
         * H: Continúa hablando, ¿ibas a decir algo de mi destino?
         * S: Ah, sí. Debes de ayudar a salvar el más allá de las garras de un ente maligno. Tú, Hana, eres la elegida.
         * H: Qué es esto ahora, ¿el zelda?
         * S: Hana, por favor, que nos lo tiran por copyright.
         * S: El caso es que necesitamos tu ayuda.
         * H: No estoy muy segura, ¿qué tendría que hacer?
         * S: Pues irías por los distintos umbrales, salvando las almas de los espíritus con ayuda de un arma mágica...
         * H: ¿Has dicho arma mágica?¿Hablas de una espada maldita que usa la fuerza vital del portador o algo más del estilo un arma con alma y consciencia propias?
         * S: Pues... Esas ideas hubieran estado bastante bien, sí. Pero solo es una guadaña, no es nada del otro mundo...
         * H: ¿Solo una guadaña?¿Ni poderes, ni almas, ni luces?
         * S: No. Lo único que tiene de especial es que es capaz de liberar las almas de los espíritusinfectados...
         * H: Y ahora me vas a decir que solo le hace caso a la persona elegida, ¿verdad?
         * S: Pues... sí
         * H: Me lo veía venir. Pero en fin, lo intentaré. De todas formas no tengo nada mejor que hacer.
         * S: Está bien. Te hago entrega de la guadaña maestra.
         * H: Qué originales...
         * S: Bueno, antes de empezar con tu misión me gustaría pedirte un favor.
         * H: Dispara.
         * S: Verás, dejé olvidadas las llaves de la puerta al final del sótano, ¿te importaría ir a por ellas?
         * H: 1-Está bien, qué remedio(hacer tutorial) 2-Illo, haz magia de esa rara tuya y hazlo tú(saltar tutorial)
         * --------------------------------Si la respuesta fue 1----------------------------------------------
         * S: Muchas gracias, entra por la trampilla que hay detrás tuya
         * H: Pero si no había ninguna trampilla. Ah, vale, cosas raras de magia.
         * --------------------------------Si la respuesta fue 2----------------------------------------------
         * S: Está bien, de todas formas no necesitaba esas llaves
         * H: ª
         */

    }

    private void lvl1()
    {
        //conversación antes del nivel uno
    }

    private void lvl2()
    {
        //conversación antes del nivel dos
    }

    private void lvl3()
    {
        //conversación antes del nivel tres
    }

    private void lvl4()
    {
        //conversación antes del nivel cuatro
    }
}
