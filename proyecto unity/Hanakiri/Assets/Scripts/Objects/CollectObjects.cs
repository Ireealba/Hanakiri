using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private puerta puerta;
    public PowerUpController puc;
    
    void Start()
    {
        puerta = GameObject.FindGameObjectWithTag("puerta").GetComponent<puerta>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("llave"))
            {
                //aparecer puerta
                Debug.Log("Aparece puerta");
                puerta.aparecer();

            }
            else if (gameObject.CompareTag("powerUp"))
            {
                puc.agregarPowerUp(gameObject);
            }

            Debug.Log("Object collected");
            Destroy(gameObject);
        }
    }
}
