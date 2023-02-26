using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;
    private float cooldownAttack = 1.5f;
    private float actualCooldownAttack;
    [SerializeField] GameObject spiderBullet;
    //[SerializeField] SpriteRenderer sprite;
    [SerializeField] Transform controladorShoot;

    private SpriteRenderer wspider;
    [SerializeField] GameObject spider;

    void Start()
    {
        actualCooldownAttack = 0;

        wspider = spider.GetComponent<SpriteRenderer>();

        if(wspider.flipX) {
            Debug.Log("al reves");
            transform.Rotate(0f, 180f, 0f);
            controladorShoot.Rotate(0f, 180f, 0f);
        }

    }

    
    void Update()
    {

        actualCooldownAttack -= Time.deltaTime;

        Debug.DrawRay(controladorShoot.position, controladorShoot.right * rangoRaycast, Color.green, distanceRaycast);
    }

    void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(controladorShoot.position, controladorShoot.right * distanceRaycast, rangoRaycast);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player") && actualCooldownAttack < 0)
            {
                Invoke("LaunchBullet", 0.5f);
                Debug.Log("Player detected");
                animator.Play("attack");
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

        newBullet = Instantiate(spiderBullet, transform.position, transform.rotation);
    }
}
