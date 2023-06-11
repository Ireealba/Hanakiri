using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controladorViñetas : MonoBehaviour
{

    private bool finished;

    void Start()
    {
        finished = true; //poner en false al agregar animacion
        //iniciar animación
    }

    
    void Update()
    {
        if (finished)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void setTrue()
    {
        finished = true;
    }
}
