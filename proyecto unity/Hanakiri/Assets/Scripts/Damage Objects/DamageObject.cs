using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private personaje player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            player.PlayerDamaged();
        }
    }
    
}
