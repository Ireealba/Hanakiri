using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    [SerializeField] public int actualScene;
    [SerializeField] public int nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void changeNextScene(int newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
