using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player.transform.position = new Vector3(761.8489f, 8.66412f, 0);
        }
    }
}
