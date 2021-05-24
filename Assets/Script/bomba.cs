using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{

    public GameObject objeto1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("panter"))
        {
            Destroy(GameObject.FindGameObjectWithTag("panter"));
        }
    }


}

