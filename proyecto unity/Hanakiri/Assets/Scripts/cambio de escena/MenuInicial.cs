using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private int nextScene;
    [SerializeField] private Button nuevaPartida;
    [SerializeField] private Button Coleccionables;
    [SerializeField] private Button Configuracion;
    [SerializeField] private Button Logros;
    [SerializeField] private Button Salir;

    void Start()
    {
        nuevaPartida.onClick.AddListener(ChangeScene);
    }

    void Collections()
    {
        
    }

    void ChangeScene()
    {
        Debug.Log("Nueva partida, enviando a escena " + nextScene);
        SceneManager.LoadScene(nextScene);
    }
    

    
}
