using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElements : MonoBehaviour
{
    public GameObject bolsaPiedras;
    public bool showPiedras;
    public int activeSent;
    public GameObject[] sentimientos;

    void Start()
    {
        showPiedras = false;
        activeSent = 1;
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

    public void changeSentimiento(int nuevo)
    {
        sentimientos[activeSent].SetActive(false);
        activeSent = nuevo;
        sentimientos[activeSent].SetActive(true);
    }
}
