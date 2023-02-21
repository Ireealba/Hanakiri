using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    private BoxCollider2D bcollider;
    private Animator anim;

    void Start()
    {
        bcollider = GetComponent<BoxCollider2D>();
        bcollider.enabled = false;

        anim = GetComponent<Animator>();

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x, 0, scale.z);
        
    }

    public void aparecer()
    {
        anim.Play("appeard");
        bcollider.enabled = true;
    }


    
}
