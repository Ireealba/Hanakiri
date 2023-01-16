using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampilla : MonoBehaviour
{
    public Animator animator;
    public static bool activo = false;

    void Update()
    {
        if (activo == true)
        {
            animator.SetBool("aparece", true);
            
        }
        else
        {
            animator.SetBool("aparece", false);
            
        }
    }
}
