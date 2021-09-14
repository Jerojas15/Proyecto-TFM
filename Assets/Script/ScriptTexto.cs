using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptTexto : MonoBehaviour
{
    public GameObject x;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            x.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            x.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
        {

        }

}
