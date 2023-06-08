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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //scene1 = lobby scene2 = tutorial scene3 = nivel1 scene4 = nivel2 scene5 = nivel3
            if(nextScene == 1)
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
