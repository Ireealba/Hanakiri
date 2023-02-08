using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float lifeTime = 2;
    private personaje player;
    //[SerializeField] SpriteRenderer sprite;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<personaje>();
    }

    void Update()
    {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            player.PlayerDamaged();
            Destroy(gameObject);
        }
    }
}
