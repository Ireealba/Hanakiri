using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploteController : MonoBehaviour
{
    [SerializeField] GameObject muffin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("explotarrrrr");
            muffin.transform.GetComponent<muffin>().canExplote = true;
        }
        else
        {
            Debug.Log("chillingggg");

        }
    }
}
