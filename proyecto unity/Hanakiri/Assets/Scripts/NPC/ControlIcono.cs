using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIcono : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if(personaje.iconoaccion == true)
        {
            animator.SetBool("aparece", true);
        }
        else
        {
            animator.SetBool("aparece", false);
        }
    }
}
