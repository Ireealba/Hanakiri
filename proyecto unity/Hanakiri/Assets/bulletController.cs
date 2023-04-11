using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;
    private float cooldownAttack = 1.5f;
    private float actualCooldownAttack;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform controlShoot;
    [SerializeField] private Animator animator;
 
    void Start()
    {
        actualCooldownAttack = 0;
    }

    void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
        Debug.DrawRay(controlShoot.position, controlShoot.right * rangoRaycast, Color.green, distanceRaycast);
    }

    void FixedUpdate()
    {

        RaycastHit2D hit2D = Physics2D.Raycast(controlShoot.position, controlShoot.right * distanceRaycast, rangoRaycast);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player") && actualCooldownAttack < 0)
            {
                Invoke("LaunchBullet", 0.5f);
                Debug.Log("Player detected");
                animator.Play("shoot");
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
    }

    void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bullet, transform.position, transform.rotation);
    }
}
