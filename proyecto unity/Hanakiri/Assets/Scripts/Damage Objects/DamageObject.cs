using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private personaje player;
    private Rigidbody2D rb2D;
    [SerializeField]private float cooldownattack = 1.5f;
    [SerializeField]private float actualcooldownattack;
    private float inputX;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();
        rb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        actualcooldownattack = 0;
    }

    void Update()
    {
        actualcooldownattack -= Time.deltaTime;
        inputX = Input.GetAxisRaw("Horizontal");
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") &&  actualcooldownattack < 0)
        {
            Debug.Log("Player Damaged");
            player.PlayerDamaged();
            rb2D.velocity = new Vector2(10000 * -inputX, 3);
            actualcooldownattack = cooldownattack;
        }
    }
    
}
