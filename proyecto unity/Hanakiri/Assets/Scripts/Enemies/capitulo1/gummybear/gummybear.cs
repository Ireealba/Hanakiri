using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gummybear : MonoBehaviour
{
    [SerializeField] private int tipo;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer bear;
    [SerializeField] private GameObject beargo;
    [SerializeField] private GameObject todo;
    protected bool dead;


    [SerializeField] float speed = 0.5f;
    private float waitTime;
    [SerializeField] Transform[] moveSpots;
    [SerializeField] float startWaitTime = 5;
    private int i = 0;
    private Transform oldspot;

    void Start()
    {
        switch (tipo)
        {
            case 0:
                animator.Play("red");
                break;
            case 1:
                animator.Play("blue");
                break;
            case 2:
                animator.Play("yellow");
                break;
            case 3:
                animator.Play("green");
                break;
        }
        waitTime = startWaitTime;
        oldspot = transform;
        dead = GetComponent<Enemy>().dead;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if (moveSpots[i].position.x > oldspot.position.x)
        {
            bear.flipX = true;

        }
        else
        {
            bear.flipX = false;

        }

        if (waitTime <= 0)
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

        if (dead)
        {
            Destroy(todo);
        }
    }
}
