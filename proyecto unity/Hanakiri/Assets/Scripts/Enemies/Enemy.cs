using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
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
    }
}
