using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolin : MonoBehaviour
{
  //public Animator animator;
    public float jumpforce = 2f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpforce);
        }
    }
}
