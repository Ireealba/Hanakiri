using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploteController : MonoBehaviour
{
    [SerializeField] GameObject muffin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && muffin.transform.GetComponent<muffin>().playerDetected)
        {
            Debug.Log("explotarrrrr");
            muffin.transform.GetComponent<muffin>().canExplote = true;
        }

        if (collider.CompareTag("Player"))
        {
            muffin.transform.GetComponent<muffin>().playerRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")){
            muffin.transform.GetComponent<muffin>().playerRange = false;
        }
    }

}
