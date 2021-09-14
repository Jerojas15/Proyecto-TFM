using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xui : MonoBehaviour
{

    public GameObject textito;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Interactuar")  && collision.CompareTag("Player"))
        {
            textito.SetActive(true);


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textito.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
