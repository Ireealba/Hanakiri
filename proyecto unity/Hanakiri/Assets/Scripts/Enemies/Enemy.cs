using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private int cantMonedas;
    private Animator animator;
    private personaje player;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        //animacion daño
        Debug.Log("Enemy damaged");

        if(vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        //animacion muerte
        Destroy(gameObject);
        Debug.Log("Enemy dead");
        player.SumarMonedas(cantMonedas);
    }
}
