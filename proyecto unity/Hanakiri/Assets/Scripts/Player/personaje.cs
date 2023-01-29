using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour
{
    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    //controlador suelo
    [SerializeField] private LayerMask isGround;
    [SerializeField] private Transform checkGround;
    [SerializeField] private Vector3 dimensionGround;
    [SerializeField] private bool ground;

    //controlador pared
    [SerializeField] private Transform checkWall;
    [SerializeField] private Vector3 dimensionWall;
    private bool wall;

    //movimiento
    private float horizontalMove = 0f;
    [SerializeField] private float moveSpeed;
    [Range(0, 0.3f)][SerializeField] private float moveSuavizador;
    private Vector3 speed = Vector3.zero;
    private bool lookRight = true;
    private float inputX;

    //salto
    [SerializeField] private float jumpForce;
    [SerializeField] private float doubleJumpForce;
    private bool jump = false;
    private bool canDoubleJump;

    //lobby
    public bool lobby;
    public static bool accion = false;
    public static bool iconoaccion = false;

    //dash
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    private float initialGravity;
    private bool canDash = true;
    private bool canMove = true;


    //wallsliding
    private bool sliding;
    [SerializeField] private float slideSpeed;

    //walljump
    [SerializeField] private float wallJumpPowerX;
    [SerializeField] private float wallJumpPowerY;
    [SerializeField] private float wallJumpTime;
    private bool wallJumping;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Scene scene = SceneManager.GetActiveScene();

        initialGravity = rb2D.gravityScale;

        //nos indicará si estamos o no en el lobby para desactivar o activar algunas funciones
        if (scene.name == "lobby")
        {
            //animator.SetBool("Lobby", true);
            lobby = true;
        }
        else
        {
            //animator.SetBool("Lobby", false);
            lobby = false;
        }
    } 

    private void Update()
    {
        //posición en x y movimiento
        inputX = Input.GetAxisRaw("Horizontal");
        horizontalMove = inputX * moveSpeed;
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMove));
        animator.SetFloat("Vertical", rb2D.velocity.y);

        //deslizarse pared
        animator.SetBool("Sliding", sliding);

        if (!ground && wall && inputX != 0)
        {
            sliding = true;
        }
        else
        {
            sliding = false;
        }

        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        //salto (en el lobby desactivado)
        if (Input.GetButtonDown("Jump") && ground && !sliding && !lobby)
        {
            jump = true;
            
        }
        else if(Input.GetButtonDown("Jump") && !ground && canDoubleJump && !sliding && !lobby)
        {
            jump = true;
        }
        else if(Input.GetButtonDown("Jump") && wall && sliding && !lobby)
        {
            WallJump();
        }

    }

    void FixedUpdate()
    {
        //crear caja para saber si está en suelo
        ground = Physics2D.OverlapBox(checkGround.position, dimensionGround, 0f, isGround);
        animator.SetBool("Ground", ground);

        //crear caja para saber si está en pared
        wall = Physics2D.OverlapBox(checkWall.position, dimensionWall, 0f, isGround);


        //si no hay un dialogo
        if (ObjetoInteractable.dialogo == false )
        {
            if (!wallJumping)
            {
                if (canMove)
                {
                    //moverse y saltar
                    Move(horizontalMove * Time.fixedDeltaTime, jump);
                }
                

                jump = false;

                //deslizarse por pared
                if (sliding)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -slideSpeed, float.MaxValue));
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //aparece icono de accion
        if (collision.tag == "cuadro de accion")
        {
            accion = true;
            iconoaccion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //desaparece icono de accion
        if (collision.tag == "cuadro de accion")
        {
            accion = false;
            iconoaccion = false;
        }
    }

    private void Move(float move, bool jump)
    {
        Vector3 speedObject = new Vector2(move, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, speedObject, ref speed, moveSuavizador);

        if(move > 0 && !lookRight)
        {
            Girar();
        }
        else if(move < 0 && lookRight)
        {
            Girar();
        }

        if(jump)
        {
            if (!canDoubleJump && ground)
            {
                ground = false;
                canDoubleJump = true;
                rb2D.AddForce(new Vector2(0f, jumpForce));
            }
            else if (canDoubleJump && !ground)
            {
                ground = false;
                animator.SetBool("DoubleJump", true);
                rb2D.AddForce(new Vector2(0f, doubleJumpForce));
                canDoubleJump = false;
            }

        }
        else if(ground)
        {
            jump = false;
            canDoubleJump = false;
            animator.SetBool("DoubleJump", false);
        }
    }

    private void Girar()
    {
        lookRight = !lookRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(checkGround.position, dimensionGround);
        Gizmos.DrawWireCube(checkWall.position, dimensionWall);
    }

    private void WallJump()
    {
        wall = false;
        animator.Play("doubleJump");
        rb2D.velocity = new Vector2(wallJumpPowerX * -inputX, wallJumpPowerY);

        StartCoroutine(ChangeWallJump());
    }

    IEnumerator ChangeWallJump()
    {
        wallJumping = true;
        yield return new WaitForSeconds(wallJumpTime);
        wallJumping = false;
    }

    private IEnumerator Dash()
    {
        canMove = false;
        canDash = false;
        rb2D.gravityScale = 0;
        rb2D.velocity = new Vector2(dashSpeed * transform.localScale.x, 0);
        animator.SetTrigger("Dashing");

        yield return new WaitForSeconds(dashTime);

        canMove = true;
        canDash = true;
        rb2D.gravityScale = initialGravity;
    }
}
