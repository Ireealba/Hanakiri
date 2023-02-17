using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSlide : MonoBehaviour
{
    [Range(1, 12)][SerializeField] private int slideType;
    [SerializeField] private Animator animator;
    [SerializeField] private PolygonCollider2D[] colliders;
    [SerializeField] private GameObject spider;
    [SerializeField] private GameObject tela;
    private int currentColliderIndex = 0;
    

    void Start()
    {
        switch (slideType)
        {
            case 1:
                animator.Play("slide1");
                break;

            case 2:
                animator.Play("slide2");
                break;

            case 3:
                animator.Play("slide3");
                break;

            case 4:
                animator.Play("slide4");
                break;

            case 5:
                animator.Play("slide5");
                break;

            case 6:
                animator.Play("slide6");
                break;

            case 7:
                animator.Play("slide7");
                break;

            case 8:
                animator.Play("slide8");
                break;

            case 9:
                animator.Play("slide9");
                break;

            case 10:
                animator.Play("slide10");
                break;

            case 11:
                animator.Play("slide11");
                break;

            case 12:
                animator.Play("slide12");
                break;
        }
        

       
    }

    void Update()
    {
        if(spider == null)
        {
            Destroy(tela);
            Destroy(gameObject);
        }
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }

}
