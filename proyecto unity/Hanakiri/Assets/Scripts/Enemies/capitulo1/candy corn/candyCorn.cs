using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candyCorn : MonoBehaviour
{
    //general
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer corn;
    [SerializeField] private GameObject corngo;
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
    [SerializeField] private GameObject actioner;
    private bool playerDetectedR;
    private bool playerDetectedL;
    [SerializeField] private Transform shootControllerL;
    [SerializeField] private Transform shootControllerR;
    private bool rotated;

    private void Start()
    {
        waitTime = startWaitTime;
        oldspot = transform;
        moving = false;
        lookRight = false;
        canRotate = true;

    }

    private void Update()
    {
        playerDetectedL = spawnP.transform.GetComponent<cornBulletController>().playerDetectedL;
        playerDetectedR = spawnP.transform.GetComponent<cornBulletController>().playerDetectedR;

        if (moving)
        {
            Debug.Log("Se puede mover");

            if (!spawnP.transform.GetComponent<cornBulletController>().shooting)
            {
                Debug.Log("No ataca así que se puede mover");
                animator.Play("move");
            }
        }
        else if (!moving)
        {
            Debug.Log("No se mueve");

            if (!spawnP.transform.GetComponent<cornBulletController>().shooting)
            {
                Debug.Log("Tampoco ataca");
                animator.Play("idle");
            }
        }

        if(transform.position.x == moveSpots[i].transform.position.x)
        {
            Debug.Log("En waypoint");
            moving = false;

            if (canRotate)
            {
                Debug.Log("Gira");
                Girar();
                canRotate = false;
            }
        }
        else
        {
            if (rotated)
            {
                Girar();
                rotated = false;
            }

            Debug.Log("No está en waypoint");
            moving = true;
            canRotate = true;
        }

        if(!playerDetectedL && !playerDetectedR)
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
                moving = false;

                if((playerDetectedL && lookRight) || (playerDetectedR && !lookRight))
                {
                    Girar();
                    rotated = true;
                }

                if(spawnP.transform.GetComponent<cornBulletController>().actualCooldownAttack < 0)
                {
                    spawnP.transform.GetComponent<cornBulletController>().Shoot();
                }           
            }

            if (corngo == null)
            {
                Destroy(todo);
            }
        }

        void Girar()
        {
            lookRight = !lookRight;

            corngo.transform.Rotate(0f, 180f, 0f);
            shootControllerL.Rotate(0f, 180f, 0f);
            shootControllerR.Rotate(0f, 180f, 0f);
        }
    }

}
