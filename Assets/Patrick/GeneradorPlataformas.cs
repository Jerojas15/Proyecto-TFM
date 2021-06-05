using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlataformas : MonoBehaviour
{
    private const float distanciaParaGenerarPlataforma = 50f;
    [SerializeField] private Transform inicioNivel;
    [SerializeField] private List<Transform> listaPlataformas;
    [SerializeField] private PlayerP player;
    [SerializeField] private int numPlataformasFinal;

    static public bool existeEnemigoPuente;

    private Vector3 ultimaPosicionFinal;
    private int numActualPlataformas;
    private void Awake()
    {
        ultimaPosicionFinal = inicioNivel.Find("PosicionFinal").position;
        numActualPlataformas = 0;
        existeEnemigoPuente = true;
    }

    private void Update()
    {
        if(!existeEnemigoPuente)
        {
            numActualPlataformas = numPlataformasFinal;
        }
        if(Vector3.Distance(player.transform.position,ultimaPosicionFinal) < distanciaParaGenerarPlataforma && numActualPlataformas < numPlataformasFinal)
        {
            GenerarPlataforma();
            numActualPlataformas++;
        }
        else if (Vector3.Distance(player.transform.position, ultimaPosicionFinal) < distanciaParaGenerarPlataforma && numActualPlataformas == numPlataformasFinal)
        {
            Transform plataformaEscogida = listaPlataformas[listaPlataformas.Count-1];
            Transform ultimaPosicionFinalPlataforma = GenerarPlataforma(plataformaEscogida, ultimaPosicionFinal);
            ultimaPosicionFinal = ultimaPosicionFinalPlataforma.Find("PosicionFinal").position;
            numActualPlataformas++;
        }
        else if (numActualPlataformas > numPlataformasFinal)
        {
            //Debug.Log("hola");
        }
    }

    private void GenerarPlataforma()
    {
        Transform plataformaEscogida = listaPlataformas[Random.Range(0, listaPlataformas.Count-1)];
        Transform ultimaPosicionFinalPlataforma = GenerarPlataforma(plataformaEscogida, ultimaPosicionFinal);
        ultimaPosicionFinal = ultimaPosicionFinalPlataforma.Find("PosicionFinal").position;
    }

    private Transform GenerarPlataforma(Transform plataformaIndex, Vector3 posicionPlataforma)
    {
        Transform plataformaTransform = Instantiate(plataformaIndex, posicionPlataforma, Quaternion.identity);
        return plataformaTransform;
    }
}
