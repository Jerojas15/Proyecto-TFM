using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton2Objetos : MonoBehaviour
{

    public GameObject objeto;
    public GameObject objeto2;
    public GameObject cartel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cartel.SetActive(true);
        }

        if (Input.GetButtonDown("Interactuar") && collision.CompareTag("Player"))
        {
            Destroy(objeto);
            Destroy(objeto2,5.0f);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cartel.SetActive(false);
        }
    }
}
