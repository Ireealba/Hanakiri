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
    [SerializeField] private GameObject actioner;
    



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
            Debug.Log("Se puede mover");

            if (!spawnP.transform.GetComponent<bulletController>().shooting)
            {
                Debug.Log("No ataca así que se puede mover");
                animator.Play("move");
            }
            
        }
        else if(!moving)
        {
            Debug.Log("No se mueve");

            if (!spawnP.transform.GetComponent<bulletController>().shooting){
                Debug.Log("Tampoco ataca");
                animator.Play("idle");
            }
            
        }

        if (transform.position.x == moveSpots[i].transform.position.x)
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
            Debug.Log("No está en waypoint");
            moving = true;
            canRotate = true;
        }


        if (!spawnP.transform.GetComponent<bulletController>().playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

            

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
