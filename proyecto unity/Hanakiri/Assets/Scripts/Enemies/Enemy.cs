using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private int cantMonedas;
    private Animator animator;
    private personaje player;
    [SerializeField] private GameObject destroyObject;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();

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
        if(destroyObject.gameObject.name == "BossSpider")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(destroyObject);

        }
        Debug.Log("Enemy dead");
        player.SumarMonedas(cantMonedas);
    }
}
