using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour
{

    public float runSpeed = 10;
    public float jumpSpeed = 310;
    public float doubleJumpSpeed = 2;
   

    private bool canDoubleJump;

    Rigidbody2D rb2D;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool lobby;
    public static bool accion = false;
    public static bool iconoaccion = false;

    public float dashCooldown;
    public float dashForce = 30;
    public GameObject dashParticle;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "lobby")
        {
            animator.SetBool("Lobby", true);
            lobby = true;
        }
        else
        {
            animator.SetBool("Lobby", false);
            lobby = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "cuadro de accion")
        {
            accion = true;
            iconoaccion= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "cuadro de accion")
        {
            accion = false;
            iconoaccion= false;
        }
    }

    private void Update()
    {
        dashCooldown -= Time.deltaTime;

        if (Input.GetKey("space"))
        {
            if(CheckGround.isGrounded && lobby == false)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
            
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
            if ((Input.GetKeyDown("d") || Input.GetKeyDown("right") || Input.GetKeyDown("a") || Input.GetKeyDown("left")))
            {
                animator.SetBool("Run", true);
        }

        }

        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }else if(rb2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    void FixedUpdate()
    {
        if (ObjetoInteractable.dialogo == false )
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {

                rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
                spriteRenderer.flipX = false;
                animator.SetBool("Run", true);

            }
            else if (Input.GetKey(KeyCode.LeftShift) && dashCooldown <= 0)
            {
                animator.SetBool("Dash", true);
                Dash();
                animator.SetBool("Dash", false);
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {

                rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
                spriteRenderer.flipX = true;
                animator.SetBool("Run", true);

            }
            else
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                animator.SetBool("Run", false);
            }

            if (betterJump)
            {

                if (rb2D.velocity.y < 0)
                {
                    rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
                }

                if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
                {
                    rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
                }

            }
        }
    }

    public void Dash()
    {
        GameObject dashObject;

        dashObject = Instantiate(dashParticle, transform.position, transform.rotation);
        

        if(spriteRenderer.flipX == true)
        {
            rb2D.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        }
        else
        {
            rb2D.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }

        dashCooldown = 2;

        

        Destroy(dashObject, 1);
    }

}
