using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] activar;
    [SerializeField] private GameObject[] desactivar;
    [SerializeField] private bool inicio;

    private void Start()
    {
        if (inicio)
        {
            for (int i = 0; i < activar.Length; i++)
            {
                activar[i].SetActive(true);
            }

            for (int i = 0; i < desactivar.Length; i++)
            {
                desactivar[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < activar.Length; i++)
            {
                activar[i].SetActive(true);
            }

            for (int i = 0; i < desactivar.Length; i++)
            {
                desactivar[i].SetActive(false);
            }
        }

            
    }

}
