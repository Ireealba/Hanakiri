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
    [SerializeField] private BoxCollider2D colliderllave;
    [SerializeField] private Transform llave;

    void Start()
    {
       
    }

    void Update()
    {
        if (spider == null)
        {
            colliderllave.enabled = true;
            llave.localScale = new Vector3 (0.3414f, 0.3414f, 0.3414f);
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
