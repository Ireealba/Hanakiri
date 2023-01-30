using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSlide : MonoBehaviour
{
    [Range(1, 8)][SerializeField] private int slideType;
    [SerializeField] private Animator animator;

    void Start()
    {
        /*
        switch (slideType)
        {
            case 1:
                animator.SetBool("slide1", true);
                break;

            case 2:
                animator.SetBool("slide2", true);
                break;

            case 3:
                animator.SetBool("slide3", true);
                break;

            case 4:
                animator.SetBool("slide4", true);
                break;

            case 5:
                animator.SetBool("slide5", true);
                break;

            case 6:
                animator.SetBool("slide6", true);
                break;

            case 7:
                animator.SetBool("slide7", true);
                break;

            case 8:
                animator.SetBool("slide8", true);
                break;
        }
        */

        if(slideType == 7)
        {
            animator.Play("slide7");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {

    }
}
