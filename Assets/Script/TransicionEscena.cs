using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{

    [SerializeField] private Animator transicion;
    [SerializeField] private float tiempoTransicion = 1f;
    private bool pauseFlag = false;


    // Update is called once per frame
    void Update()
    {
        if(pauseFlag)
        {
            StartCoroutine(TiempoInicial());
        }

        if(transicion.isActiveAndEnabled)
        {
            transicion.SetBool("TransicionActivaInicio", false);
        }

        /*if(Input.GetMouseButtonDown(0))
        {
            CargarSiguienteEscena();
        }*/
    }

    public void CargarSiguienteEscena()
    {
        StartCoroutine(CargarEscena(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator CargarEscena(int escenaIndex)
    {
        transicion.SetTrigger("InicioTransicion");
        transicion.SetBool("TransicionActiva", true);
        yield return new WaitForSeconds(tiempoTransicion);
        transicion.SetBool("TransicionActiva", false);
        
        SceneManager.LoadScene(escenaIndex);
    }

    IEnumerator TiempoInicial()
    {
        yield return new WaitForSeconds(1);
        //pauseFlag = false;
    }
}
