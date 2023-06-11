using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField] public int actualScene;
    [SerializeField] public int nextScene;
    public personaje player;
    public DataController dc;

    private void Start()
    {
        dc = GameObject.Find("DataController").GetComponent<DataController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();
        dc.ChargeData();
    }

    private void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();
        }

        if(dc == null)
        {
            dc = GameObject.Find("DataController").GetComponent<DataController>();
            dc.ChargeData();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //scene1 = lobbylvl0 scene11 = lobbylvl1
            //scene2 = tutorial scene3 = nivel1 scene4 = nivel2 scene5 = nivel3
            if(nextScene == 6)
            {
                switch(actualScene)
                {
                    case 2:

                        player.actualLvl = 1;

                        break;

                    case 3:
                        player.actualLvl = 2;

                        break;

                    case 4:
                        player.actualLvl = 3;
                        
                        break;
                }
            }

            dc.SaveData();


            SceneManager.LoadScene(nextScene);
        }
    }

    public void changeNextScene(int newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
