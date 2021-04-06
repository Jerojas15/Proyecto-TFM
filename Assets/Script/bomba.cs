using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{

    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rocaGigante"))
        {
            Destroy(objeto1);
            Destroy(objeto2);
            Destroy(objeto3);

        }
    }

    
}

