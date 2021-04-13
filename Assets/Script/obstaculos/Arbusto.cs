using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbusto : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerP>().reducirVelocidad(80);
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerP>().restaurarVelocidad();
        }
    }
}
