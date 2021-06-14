using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{

    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject rocadesactivada;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("panter"))
        {
            Destroy(objeto1);

            rocadesactivada.SetActive(true);
            Destroy(objeto2,3.0f);
        }
        
    }
 

}

