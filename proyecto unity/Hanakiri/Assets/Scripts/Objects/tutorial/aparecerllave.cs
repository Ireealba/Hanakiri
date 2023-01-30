using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparecerllave : MonoBehaviour
{
    public bool activo = false;
    [SerializeField] private BoxCollider2D colliderbox;
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(activo == true)
        {
            animator.SetBool("appear", true);
            colliderbox.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            activo = false;
            animator.SetBool("appear", false);
            //aparecerPuerta.activo = true;
            collider.enabled = false;
        }
           
    }
}
