using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muffin : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;

    [SerializeField] Transform controlRaycast;
    [SerializeField] Transform npcBody;
    [SerializeField] Transform npc;
    private bool move;
    private bool stopped;
    private bool exploted;
    public bool canExplote;
    [SerializeField] private bool lookRight;
    [SerializeField] private float moveSpeed;


    void Start()
    {
        move = false;
        stopped = true;
        exploted = false;
        canExplote = false;
    }

    void Update()
    {
        if(move)
        {
            animator.Play("run");
            Move(moveSpeed);
            stopped = false;
        }
        else if(!move && !stopped)
        {
            animator.Play("idle");
            Stop();
            stopped = true;
        }
        else if (exploted)
        {
            //destruir todo

        }

        //dibujar raycast
        Debug.DrawRay(controlRaycast.position, controlRaycast.right * rangoRaycast, Color.green, distanceRaycast);
    }

    void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(controlRaycast.position, controlRaycast.right * distanceRaycast, rangoRaycast);

        if(hit2D.collider != null) {

            Debug.Log("colisionando con " + hit2D.collider.name);

            if (hit2D.collider.CompareTag("Player"))
            {
                Debug.Log("Player detected");

                if (!move)
                {
                    move = true;
                }
                else if (canExplote)
                {
                    Stop();
                    Explote();
                }
            }
            else
            {
                Debug.Log("Player not detected");
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

    }

    private void Explote()
    {
        Debug.Log("explotar");
        animator.Play("explosion");
    }

    
}
