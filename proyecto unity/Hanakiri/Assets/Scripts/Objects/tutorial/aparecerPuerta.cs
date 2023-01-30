using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aparecerPuerta : MonoBehaviour
{
    public bool activo = false;
    [SerializeField] private BoxCollider2D colliderbox;
    [SerializeField] private Animator animator;
    [SerializeField] private int nextScene;

    // Update is called once per frame
    void Update()
    {
        if (activo == true)
        {
            animator.SetBool("appear", true);
            colliderbox.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
