using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInicioPuente : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enemigo.GetComponent<Enemigo_NivelPuente>().perseguir = true;
            //Debug.Log("gople");
            //SceneManager.LoadScene("Puente");
        }
    }
    
}
