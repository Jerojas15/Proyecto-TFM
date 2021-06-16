using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElements : MonoBehaviour
{
    public GameObject bolsaPiedras;
    public bool showPiedras;

    void Start()
    {
        showPiedras = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void togglePiedras()
    {
        showPiedras = !showPiedras;
        bolsaPiedras.SetActive(showPiedras);
    }
}
