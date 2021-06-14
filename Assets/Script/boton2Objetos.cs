using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton2Objetos : MonoBehaviour
{

    public GameObject objeto;
    public GameObject objeto2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Interactuar") && collision.CompareTag("Player"))
        {
            Destroy(objeto);
            objeto2.SetActive(false);
            
        }
    }
}
