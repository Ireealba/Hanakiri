using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampilla : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;
    public BoxCollider2D colliderTrampillaSuelo;
    public BoxCollider2D colliderTrampillaPared;
    public BoxCollider2D colliderSuelo;
    public bool activo = false;

    void Update()
    {
        if (activo == true)
        {
            animator1.SetBool("aparece", true);
            animator2.SetBool("aparece", true);
            colliderSuelo.enabled = false;
            colliderTrampillaSuelo.enabled = true;
            colliderTrampillaPared.enabled = true;
            
        }
        else
        {
            animator1.SetBool("aparece", false);
            animator2.SetBool("aparece", false);
            colliderSuelo.enabled = true;
            colliderTrampillaSuelo.enabled = false;
            colliderTrampillaPared.enabled = false;
        }
    }
}
