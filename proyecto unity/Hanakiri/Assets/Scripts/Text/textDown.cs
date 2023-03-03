using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textDown : MonoBehaviour
{
    [TextArea(2, 6)]
    public string texto;
    [SerializeField] TextMeshProUGUI textoPantalla;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            textoPantalla.text = texto;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textoPantalla.text = "";
        }
    }
}
