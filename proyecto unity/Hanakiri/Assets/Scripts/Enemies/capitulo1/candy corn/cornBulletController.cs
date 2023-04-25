using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornBulletController : MonoBehaviour
{
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;
    private float cooldownAttack = 2f;
    public float actualCooldownAttack;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform controlShootL;
    [SerializeField] Transform controlShootR;
    [SerializeField] private Animator animator;
    public bool playerDetectedL;
    public bool playerDetectedR;
    public bool shooting;
    [SerializeField] GameObject setFalse;

    private void Start()
    {
        actualCooldownAttack = 0;
        playerDetectedL = false;
        playerDetectedR = false;
        shooting= false;

    }

    private void Update()
    {
        actualCooldownAttack -= Time.deltaTime;

        Debug.DrawRay(controlShootL.position, controlShootL.right * rangoRaycast, Color.green, distanceRaycast);
        Debug.DrawRay(controlShootR.position, controlShootR.right * rangoRaycast, Color.green, distanceRaycast);

        shooting = setFalse.transform.GetComponent<SetFalse>().shoot;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2DL = Physics2D.Raycast(controlShootL.position, controlShootL.right * distanceRaycast, rangoRaycast);
        RaycastHit2D hit2DR = Physics2D.Raycast(controlShootR.position, controlShootR.right * distanceRaycast, rangoRaycast);

        if(hit2DL.collider != null)
        {
            Debug.Log("colisionando por la izquierda con " + hit2DL.collider.name);

            if (hit2DL.collider.CompareTag("Player"))
            {
                playerDetectedL = true;
                playerDetectedR = false;
            }
            else
            {
                playerDetectedL = false;
            }
        }
        else if(hit2DR.collider != null)
        {
            Debug.Log("collisionando por la derecha con " + hit2DR.collider.name);

            if (hit2DR.collider.CompareTag("Player"))
            {
                playerDetectedR = true;
                playerDetectedL = false;
            }
            else
            {
                playerDetectedR = false;
            }
        }
        else
        {
            playerDetectedR = false;
            playerDetectedL = false;
        }
    }

    void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bullet, transform.position, transform.rotation);

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
