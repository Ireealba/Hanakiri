using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donut : MonoBehaviour
{
    //general
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer dona;
    [SerializeField] private GameObject donago;
    [SerializeField] private GameObject todo;

    //move
    [SerializeField] float speed = 0.5f;
    private float waitTime;
    [SerializeField] Transform[] moveSpots;
    [SerializeField] float startWaitTime = 5;
    private int i = 0;
    private Transform oldspot;
    private bool moving;
    private bool canRotate;
    [SerializeField] private bool lookRight;

    //detect player
    [SerializeField] private GameObject spawnP;
    



    void Start()
    {
        waitTime = startWaitTime;
        oldspot = transform;
        moving = false;
        lookRight = false;
        canRotate = true;

    }

    void Update()
    {
        

        if (moving)
        {
            animator.Play("move");
        }
        else if(!moving && !spawnP.transform.GetComponent<bulletController>().shooting)
        {
            animator.Play("idle");
        }




        if (!spawnP.transform.GetComponent<bulletController>().playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

            if (transform.position.x == moveSpots[i].transform.position.x)
            {
                moving = false;

                if (canRotate)
                {
                    Girar();
                    canRotate = false;
                }
            }
            else
            {
                moving = true;
                canRotate = true;
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
        }
        else
        {
            moving = false;
            
            if(spawnP.transform.GetComponent<bulletController>().actualCooldownAttack < 0)
            {
                animator.Play("shoot");
                spawnP.transform.GetComponent<bulletController>().Shoot();


            }
            
        }

        if(donago == null)
        {
            Destroy(todo);
        }
    }

    private void Girar()
    {
        lookRight = !lookRight;

        donago.transform.Rotate(0f, 180f, 0f);
    }


    

}
