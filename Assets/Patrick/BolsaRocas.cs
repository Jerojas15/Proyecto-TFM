﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolsaRocas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.transform.CompareTag("Player"))
        {
            PlayerP.permitirDisparar = true;
            Destroy(this.gameObject);
        }
    }
}
