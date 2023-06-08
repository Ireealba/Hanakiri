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
    [SerializeField] private Button BotonColeccionables;
    [SerializeField] private Button BotonConfiguracion;
    [SerializeField] private Button BotonLogros;
    [SerializeField] private Button Salir;
    [SerializeField] private DataController dataC;
    public ObjectsController oc;

    void Start()
    {
        nuevaPartida.onClick.AddListener(Newgame);
        continuar.onClick.AddListener(ContinueGame);
        BotonColeccionables.onClick.AddListener(Coleccionables);
        BotonLogros.onClick.AddListener(Logros);
        BotonConfiguracion.onClick.AddListener(Configuracion);
    }

    void Newgame()
    {
        
        Debug.Log("Nueva partida, enviando a escena " + nextScene);
        dataC.DeleteData();
        oc.DeleteData();
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

    void Coleccionables()
    {
        SceneManager.LoadScene("BotonColeccionables");
    }

    void Logros()
    {
        SceneManager.LoadScene("BotonLogros");
    }

    void Configuracion()
    {
        SceneManager.LoadScene("BotonConfiguracion");
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
