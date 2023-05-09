using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private int cantMonedas;
    private Animator animator;
    private personaje player;
    public bool dead;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();
        dead = false;
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        //TODO animacion daño
        Debug.Log("Enemy damaged");

        if(vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {

        //TODO animacion muerte
        dead = true;
        Destroy(gameObject);
        Debug.Log("Enemy dead");
        player.SumarMonedas(cantMonedas);
    }
}
