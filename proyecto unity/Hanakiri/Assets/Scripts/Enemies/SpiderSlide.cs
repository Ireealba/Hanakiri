using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSlide : MonoBehaviour
{
    [Range(1, 8)][SerializeField] private int slideType;
    [SerializeField] private Animator animator;
    [SerializeField] private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    void Start()
    {
        if(slideType == 1)
        {
            animator.Play("slide1");
        }
        else if(slideType == 2)
        {
            animator.Play("slide2");
        }
        else if(slideType == 3)
        {
            animator.Play("slide3");
        }
        else if(slideType == 4)
        {
            animator.Play("slide4");
        }
        else if(slideType == 5)
        {
            animator.Play("slide5");
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

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
}
