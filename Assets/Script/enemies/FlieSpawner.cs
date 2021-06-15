using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlieSpawner : MonoBehaviour
{
    public GameObject flie;
    public GameObject spawner;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(flie, spawner.transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
