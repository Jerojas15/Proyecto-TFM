using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chuzitos : MonoBehaviour
{

    public FoxGuardian foxGuardian;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso") || collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            foxGuardian.vida -= 1;
            Destroy(gameObject,2);
        }
    }
}
