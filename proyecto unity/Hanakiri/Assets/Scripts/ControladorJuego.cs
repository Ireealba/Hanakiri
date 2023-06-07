using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Instance;
    [SerializeField] private GameObject[] puntosDeControl;

    [SerializeField] private GameObject jugador;

    private int IndexPuntodeControl;
    
    private void Awake()
    {
        Instance = this;
        /*if(IndexPuntodeControl>= puntosDeControl.Length)
        {
            PlayerPrefs.SetInt("puntosIndex", 1);
            IndexPuntodeControl = 0;
        }
        */
        IndexPuntodeControl = 0;
        IndexPuntodeControl = PlayerPrefs.GetInt("puntosIndex");
        Instantiate(jugador, puntosDeControl[IndexPuntodeControl].transform.position, Quaternion.identity);

    }

    
    public void UltimoPuntoControl(GameObject puntoControl)
    {
        for(int i=0; i < puntosDeControl.Length; i++)
        {
            if (puntosDeControl[i] == puntoControl && i>IndexPuntodeControl)
            {
                PlayerPrefs.SetInt("puntosIndex", i);
            }
            
            
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



}
