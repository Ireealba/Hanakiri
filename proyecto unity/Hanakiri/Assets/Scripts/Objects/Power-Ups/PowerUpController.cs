using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpController : MonoBehaviour
{

    public PowerUp[] powerUps;
    public GameObject player;
    public ObjectsController oc;
    public GameObject[] pUp;
    public ShopController sc;
    

    private int timer;
    private bool charged;

    private void Start()
    {
        oc = FindObjectOfType<ObjectsController>();

        if(oc != null)
        {
            oc.ChargeData();
            charged = true;
            Debug.Log("Hay oc");
            Debug.Log(oc);
        }
        else
        {
            Debug.Log("no se encontró ningun tipo oc");
        }

        
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "shop")
        {
            sc.AsignarProductos();
        }
    }


    public void agregarPowerUp(GameObject pup)
    {
        int index = powerUps.Length + 1;

        for(int i = 0; i < powerUps.Length; i++)
        {
            if(pup.name == powerUps[i].name)
            {
                index = i;
                Debug.Log("agregado: " + pup.name);
            }
        }

        if(index >= 0 && index <= powerUps.Length)
        {
            player.GetComponent<personaje>().actualLife += powerUps[index].life;
            player.GetComponent<personaje>().moveSpeed += powerUps[index].speed;
            player.GetComponent<personaje>().jumpForce += powerUps[index].jump;
            player.GetComponent<personaje>().doubleJumpForce += powerUps[index].jump / 4;
            player.GetComponent<ComboCharacter>().damage += powerUps[index].attack;
            player.GetComponent<personaje>().monedas += powerUps[index].monedas;
            powerUps[index].active = true;

            oc.SaveData();
            charged = false;
        }
        else
        {
            Debug.Log("index erroneo");
        }


    }

    public void quitarPowerUp(GameObject pup)
    {
        int index = powerUps.Length + 1;

        for (int i = 0; i < powerUps.Length; i++)
        {
            if (pup.name == powerUps[i].name)
            {
                index = i;
            }
        }
        if (index >= 0 && index <= powerUps.Length)
        {
            player.GetComponent<personaje>().actualLife -= powerUps[index].life;
            player.GetComponent<personaje>().moveSpeed -= powerUps[index].speed;
            player.GetComponent<personaje>().jumpForce -= powerUps[index].jump;
            player.GetComponent<personaje>().doubleJumpForce -= powerUps[index].jump / 4;
            player.GetComponent<ComboCharacter>().damage -= powerUps[index].attack;
            player.GetComponent<personaje>().monedas -= powerUps[index].monedas;
            powerUps[index].active = false;

            oc.SaveData();
            charged = false;
        }
        else
        {
            Debug.Log("index erroneo");
        }
    }

    void Update()
    {
        if (!charged)
        {
            oc.ChargeData();
        }



        /*
        if(collected && !used)
        {
            agregarPowerUp();
            used = true;
            // El timer empieza
        }

        if(timer==usingTime)
        {
            quitarPowerUp();
        }
        */
    }
}
