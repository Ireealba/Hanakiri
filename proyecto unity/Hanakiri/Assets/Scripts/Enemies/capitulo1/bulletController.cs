using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;
    private float cooldownAttack = 2f;
    public float actualCooldownAttack;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform controlShootL;
    [SerializeField] private Animator animator;
    public bool playerDetected;
    public bool shooting;
    private int j = 0;


    void Start()
    {
        //inicialización de variables
        actualCooldownAttack = 0;
        playerDetected = false;
        shooting = false;

        //StartCoroutine(waiter());
    }

    void Update()
    {
        //reducción de cooldown de ataque
        actualCooldownAttack -= Time.deltaTime;

        //dibujar raycast de detección de personaje R y L
        Debug.DrawRay(controlShootL.position, controlShootL.right * rangoRaycast, Color.green, distanceRaycast);
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

        newBullet = Instantiate(bullet, transform.position, transform.rotation);//TODO random colores
    }

    public void Shoot()
    {
        if(actualCooldownAttack < 0)
        {
            if(j == 0)
            {
                shooting = true;
                Invoke("LaunchBullet", 0.5f);
                actualCooldownAttack = cooldownAttack;
                j++;
            }
            else
            {
                animator.Play("idle");//TODO animación frame 0 de shoot
                j = 0;
            }

        }
    }

    IEnumerator waiter()
    {
        Debug.Log("waiter start");

        if (shooting)
        {
            Debug.Log("waiter shooting");
            animator.Play("shoot");

            yield return new WaitForSeconds(2);

            shooting = false;
        }
    }
}
