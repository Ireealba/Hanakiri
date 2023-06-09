using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ShopController : MonoBehaviour
{
    public PowerUpController puc;
    public GameObject[] pUp;
    public Sprite[] img;
    public int[] n;
    public personaje player;

    private void Start()
    {
        puc = GameObject.Find("powerUpsController").GetComponent<PowerUpController>();
    }
    public void AsignarProductos()
    {
        //puc.oc.ChargeData();

        /*
        Color verdeM = new Color(120, 255, 91);
        Color verdeB = new Color(206, 255, 196);
        Color rojo = new Color(255, 134, 135);
        Color naranja = new Color(255, 165, 134);
        Color[] color = new Color[] { rojo, rojo, verdeM, verdeB, rojo, rojo, naranja, naranja };
        */

        n = new int[pUp.Length];

        for(int i = 0; i < pUp.Length; i++)
        {
            bool done = false;
            int naux;

            do{

                naux = Random.Range(0, puc.powerUps.Length - 1);
                Debug.Log(naux);
                bool repeat = false;

                for(int j = 0; j < n.Length; j++)
                {
                    if(naux == n[j])
                    {
                        repeat = true;
                    }
                }

                if (!repeat)
                {
                    
                    
                        //SpriteRenderer contenedor = pUp[i].GetComponentInChildren<SpriteRenderer>();

                        n[i] = naux;
                        //Debug.Log(puc.powerUps[n].name);
                        pUp[i].name = puc.powerUps[naux].name;
                        pUp[i].GetComponent<SpriteRenderer>().sprite = img[naux];
                        //contenedor.color = color[naux];
                        Debug.Log(pUp[i].name);
                        done = true;
                    
                }

            }while(!done);
        }
    }

    public void Comprar(int index, int monedas)
    {
        if(player.monedas >= monedas)
        {
            player.monedas -= monedas;
            Debug.Log("Objecto comprado: " + pUp[index].name);
            puc.agregarPowerUp(pUp[index]);
            Destroy(pUp[index]);
        }
        else
        {
            Debug.Log("No hay dinero suficiente");
        }
    }
}
