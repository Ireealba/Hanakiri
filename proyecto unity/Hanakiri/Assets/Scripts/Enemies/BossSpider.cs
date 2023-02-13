using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpider : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;
    [SerializeField] private GameObject spider;
    [SerializeField] private GameObject tela;

    void Start()
    {
       // animator.SetBool("move", true);
    }

    void Update()
    {
        if (spider == null)
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
