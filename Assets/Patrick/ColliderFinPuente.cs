using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFinPuente : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameObject enemy = GameObject.Find("ObjetoPeligro");
            Enemigo_NivelPuente enemigo = enemy.GetComponent<Enemigo_NivelPuente>();
            enemigo.perseguir = false;
        }
    }
}
