using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muffin : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float distanceRaycast;
    [SerializeField] float rangoRaycast;

    [SerializeField] Transform controlRaycastL;
    [SerializeField] Transform controlRaycastR;
    [SerializeField] GameObject npcBody;
    [SerializeField] Transform npc;
    private bool move;
    private bool stopped;
    private bool exploted;
    public bool canExplote;
    public bool playerDetected;
    public bool playerRange;
    [SerializeField] private bool lookRight;
    [SerializeField] private float moveSpeed;
    [SerializeField] GameObject player;


    void Start()
    {
        move = false;
        stopped = false;
        exploted = false;
        canExplote = false;
        playerDetected = false;
        playerRange = false;
    }

    void Update()
    {
        if(move)
        {
            animator.Play("run");
            Move(moveSpeed);
            stopped = false;
        }
        else if (exploted)
        {
            Destroy(npcBody);

        }

        //dibujar raycast
        Debug.DrawRay(controlRaycastL.position, controlRaycastL.right * rangoRaycast, Color.green, distanceRaycast);
        Debug.DrawRay(controlRaycastR.position, controlRaycastR.right * rangoRaycast, Color.green, distanceRaycast);
    }

    void FixedUpdate()
    {
        RaycastHit2D hit2DL = Physics2D.Raycast(controlRaycastL.position, controlRaycastL.right * distanceRaycast, rangoRaycast);
        RaycastHit2D hit2DR = Physics2D.Raycast(controlRaycastR.position, controlRaycastR.right * distanceRaycast, rangoRaycast);

        if(hit2DL.collider != null) {

            Debug.Log("colisionando con " + hit2DL.collider.name);

            if (hit2DL.collider.CompareTag("Player"))//izquierda
            {
                Debug.Log("Player detected");

                if (!move && !stopped)
                {
                    lookRight = false;
                    move = true;
                    playerDetected = true;
                }else if (stopped)
                {
                    move = false;
                }
                
            }
            else
            {
                Debug.Log("Player not detected");
            }

        }
        else if(hit2DR.collider != null)//derecha
        {
            Debug.Log("colisionando con " + hit2DR.collider.name);

            if (hit2DR.collider.CompareTag("Player"))
            {
                Debug.Log("player detected");

                if(!move && !stopped)
                {
                    Girar();
                    move = true;
                    playerDetected = true;
                }else if (stopped)
                {
                    move = false;
                }

            }
        }

        if (canExplote)
        {
            Stop();
            Explote();
        }
    }

    private void Girar()
    {
        lookRight = !lookRight;

        npc.Rotate(0f, 180f, 0f);

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
        stopped = true;
        move = false;

    }

    private void Explote()
    {
        Debug.Log("explotar");
        animator.Play("explosion");
 
    }
    private void Exploted()
    {
        exploted = true;
        if (playerRange)
        {
            Debug.Log("player in range");
            player.transform.GetComponent<personaje>().PlayerDamaged();
        }
        else
        {
            Debug.Log("player out range");
        }
    }

    
}
