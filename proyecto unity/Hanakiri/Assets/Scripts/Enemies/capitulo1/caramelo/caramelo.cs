using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class caramelo : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;
    private float cooldownAttack = 1.5f;
    private float cooldownMove = 2f;
    private float actualCooldownMove;
    private float actualCooldownAttack;
    [SerializeField] Transform controlAttack;
    [SerializeField] Transform npcBody;
    [SerializeField] Transform npc;
    private bool move;
    private bool stopped;
    [SerializeField] private bool lookRight = false;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        actualCooldownAttack = 0;
        actualCooldownMove = 0;
        move = false;
        stopped = true;

    }

    void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
        actualCooldownMove -= Time.deltaTime;
        Debug.Log("acdattack= " + actualCooldownAttack + "    acdmove= " + actualCooldownMove + "    move= " + move);

        if (move)
        {
            animator.Play("move");
            Move(moveSpeed);
            stopped = false;
        }
        else if(!move && !stopped)
        {
            animator.Play("idle");
            Stop();
            stopped = true;
        }

        //dibujar raycast
        Debug.DrawRay(controlAttack.position, controlAttack.right * rangoRaycast, Color.green, distanceRaycast);
    }

    void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(controlAttack.position, controlAttack.right * distanceRaycast, rangoRaycast);

        if(hit2D.collider != null)
        {
            if(hit2D.collider.CompareTag("Player") && actualCooldownAttack < 0)
            {
                Debug.Log("Player detected by caramelo");

                if(actualCooldownAttack < 0 && !move)
                {
                    Debug.Log("actualcooldownmove<0 y actualcooldownattack<0");
                    actualCooldownMove = cooldownMove;
                    move = true;
                    Debug.Log("actualcooldownmove=cooldownmove");
                    
                } else if(actualCooldownMove > 0 && move)
                {
                    Debug.Log("actualcooldownmove>0");
                    animator.Play("move");
                    Debug.Log("animacion move iniciada");  

                } else if(actualCooldownMove < 0 && move)
                {
                    Debug.Log("actualcooldownmove<0 stop animacion move");
                    actualCooldownAttack = cooldownAttack;
                    move = false;
                    Debug.Log("actualcooldownattack=cooldownattack");
                }

                

            }
            else if (!hit2D.collider.CompareTag("Player"))
            {
                Debug.Log("caramelo colisionando con " + hit2D.collider.tag);
            }

        }
        else
        {
            Debug.Log("nothing detected");
            if(actualCooldownMove > 0)
            {
                move = true;
            }
            else
            {
                move = false;
            }
        }
    }

    private void Move(float move)
    {
        Vector2 pos = npc.position; 

        if (lookRight)
        {
            pos = new Vector2(npc.position.x + 0.2f, npc.position.y);
        }
        else
        {
            pos = new Vector2(npc.position.x - 0.2f, npc.position.y);
        }
        
        npc.position = Vector2.MoveTowards(npc.position, pos, move * Time.deltaTime);

    }

    private void Stop()
    {
        npc.position = new Vector2(npc.position.x, npc.position.y);
        Girar();
    }

    private void Girar()
    {
        lookRight = !lookRight;

        npc.Rotate(0f, 180f, 0f);

    }
}
