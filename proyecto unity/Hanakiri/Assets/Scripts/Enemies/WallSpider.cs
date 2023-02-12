using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpider : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 0.5f;
    private float waitTime;
    [SerializeField] Transform[] moveSpots;
    [SerializeField] float startWaitTime = 2;
    private int i = 0;
    private Vector2 actualPos;
    [SerializeField] private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if(waitTime <= 0)
        {
            if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }

            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }


    }


    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
}
