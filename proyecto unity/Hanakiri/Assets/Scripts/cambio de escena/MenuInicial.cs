using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private int nextScene;
    [SerializeField] private Button nuevaPartida;
    [SerializeField] private Button continuar;
    [SerializeField] private Button Coleccionables;
    [SerializeField] private Button Configuracion;
    [SerializeField] private Button Logros;
    [SerializeField] private Button Salir;

    void Start()
    {
        nuevaPartida.onClick.AddListener(Newgame);
        continuar.onClick.AddListener(ContinueGame);
    }

    void Newgame()
    {
        Debug.Log("Nueva partida, enviando a escena " + nextScene);
        SceneManager.LoadScene(nextScene);
    }

    void ContinueGame()
    {
        if(File.Exists(Application.dataPath + "/gamesaves/gamedata.json"))
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("No existen datos guardados");
        }
    }

    public void SalidaJuego()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    
    }
    
}
