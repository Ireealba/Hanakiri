using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpider : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    void Start()
    {
       // animator.SetBool("move", true);
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
