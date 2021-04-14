using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformas : MonoBehaviour
{
    private const float distanciaParaGenerarPlataforma = 50f;
    [SerializeField] private Transform inicioNivel;
    [SerializeField] private List<Transform> listaPlataformas;
    [SerializeField] private PlayerP player;

    private Vector3 ultimaPosicionFinal;
    private void Awake()
    {
        ultimaPosicionFinal = inicioNivel.Find("PosicionFinal").position;
        /*int numPlataformas = 2;
        for(int i = 0; i < numPlataformas; i++)
        {
            GenerarPlataforma();
        }*/
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position,ultimaPosicionFinal) < distanciaParaGenerarPlataforma)
        {
            GenerarPlataforma();
        }
    }

    private void GenerarPlataforma()
    {
        Transform plataformaEscogida = listaPlataformas[Random.Range(0, listaPlataformas.Count)];
        Transform ultimaPosicionFinalPlataforma = GenerarPlataforma(plataformaEscogida, ultimaPosicionFinal);
        ultimaPosicionFinal = ultimaPosicionFinalPlataforma.Find("PosicionFinal").position;
    }

    private Transform GenerarPlataforma(Transform plataformaIndex, Vector3 posicionPlataforma)
    {
        Transform plataformaTransform = Instantiate(plataformaIndex, posicionPlataforma, Quaternion.identity);
        return plataformaTransform;
    }
}
