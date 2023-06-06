using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamaraJugador : MonoBehaviour
{
    public Transform Hana;
    public CinemachineVirtualCamera camara;
    
    void Start()
    {
        Hana = GameObject.FindGameObjectWithTag("Player").transform;
        camara.Follow = Hana;
    }

   
}
