using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;
    private float cooldownAttack = 2f;
    public float actualCooldownAttack;
    [SerializeField] GameObject[] bullet;
    [SerializeField] Transform controlShootL;
    [SerializeField] private Animator animator;
    public bool playerDetected;
    public bool shooting;
    [SerializeField] GameObject setFalse;

    //cambiar de bullet
    private int bulletType;


    void Start()
    {
        //inicialización de variables
        actualCooldownAttack = 0;
        playerDetected = false;
        shooting = false;
        bulletType = 0;

        //StartCoroutine(waiter());
    }

    void Update()
    {
        //reducción de cooldown de ataque
        actualCooldownAttack -= Time.deltaTime;

        //dibujar raycast de detección de personaje R y L
        Debug.DrawRay(controlShootL.position, controlShootL.right * rangoRaycast, Color.green, distanceRaycast);

        shooting = setFalse.transform.GetComponent<SetFalse>().shoot;
    }

    void FixedUpdate()
    {

        RaycastHit2D hit2D = Physics2D.Raycast(controlShootL.position, controlShootL.right * distanceRaycast, rangoRaycast);


        if(hit2D.collider != null)
        {
            Debug.Log("colisionando con " + hit2D.collider.name);

            if (hit2D.collider.CompareTag("Player"))
            {
                playerDetected = true;
            }
            else
            {
                playerDetected = false;
            }

        }
        else
        {
            playerDetected = false; 
        }

        /*
        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player") && actualCooldownAttack < 0)
            {
                Invoke("LaunchBullet", 0.5f);
                Debug.Log("Player detected");
                animator.Play("shoot");
                wait(3);
                actualCooldownAttack = cooldownAttack;
            }
            else if (!hit2D.collider.CompareTag("Player"))
            {
                Debug.Log("colisionando con " + hit2D.collider.tag);
            }
            else
            {
                animator.Play("idle");
            }
        }
        */
    }

    void LaunchBullet()
    {

        GameObject newBullet;

        //0: azul, 1: rojo, 2: verde
        switch (bulletType)
        {
            case 0:
                newBullet = Instantiate(bullet[0], transform.position, transform.rotation);
                bulletType++;
                break;

            case 1:
                newBullet = Instantiate(bullet[1], transform.position, transform.rotation);
                bulletType++;
                break;

            case 2:
                newBullet = Instantiate(bullet[2], transform.position, transform.rotation);
                bulletType = 0;
                break;

        }

        //TODO random colores
    }

    public void Shoot()
    {
        if(actualCooldownAttack < 0 && !shooting)
        {

            animator.Play("shoot");
            Invoke("LaunchBullet", 0.5f);
           actualCooldownAttack = cooldownAttack;

        }
    }

}
