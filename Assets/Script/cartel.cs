using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartel : MonoBehaviour
{

    public GameObject imagen;
    public GameObject texto;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            imagen.SetActive(true);
        }

        if (Input.GetButtonDown("Interactuar") && collision.CompareTag("Player"))
        {
            texto.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            imagen.SetActive(false);
            texto.SetActive(false);
        }
    }
    // Start is called before the first frame update
    
}
