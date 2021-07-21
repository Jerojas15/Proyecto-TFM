using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chuzitos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso") || collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponentInChildren<Collider2D>(), GetComponent<Collider2D>());
        }
       
    }
}
