using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNubes : MonoBehaviour
{
    [SerializeField] private List<Transform> listaNubes;
    [SerializeField] private int distanciaEntreNubes;
    [SerializeField] private int posicionInicial;
    [SerializeField] private int posicionFinal;
    [SerializeField] private int alturaMinNube2;
    [SerializeField] private int alturaMinNube;
    [SerializeField] private int alturaMediaNube;
    [SerializeField] private int alturaMaxNube;
    [SerializeField] private int alturaMaxNube2;
    void Awake()
    {
        for(int i = posicionInicial; i <= posicionFinal; i++)
        {
            int posOffsetNubeInferior = Random.Range(-20, 20);
            int posOffsetNubeSuperior = Random.Range(-20, 20);

            Vector3 posNubeSuperior = new Vector3(posicionInicial + i, Random.Range(alturaMinNube, alturaMediaNube));
            Vector3 posNubeInferior = new Vector3(posicionInicial + i + posOffsetNubeInferior, Random.Range(alturaMediaNube, alturaMaxNube));
            Vector3 posNubeSuperior2 = new Vector3(posicionInicial + i, Random.Range(alturaMinNube2, alturaMinNube));
            Vector3 posNubeInferior2 = new Vector3(posicionInicial + i + posOffsetNubeSuperior, Random.Range(alturaMaxNube, alturaMaxNube2));
            
            Transform nubeEscogidaSuperior = listaNubes[Random.Range(0, listaNubes.Count)];
            Transform nubeEscogidaInferior = listaNubes[Random.Range(0, listaNubes.Count)];
            Transform nubeEscogidaSuperior2 = listaNubes[Random.Range(0, listaNubes.Count)];
            Transform nubeEscogidaInferior2 = listaNubes[Random.Range(0, listaNubes.Count)];
            
            Instantiate(nubeEscogidaSuperior, posNubeSuperior, Quaternion.identity);
            Instantiate(nubeEscogidaInferior, posNubeInferior, Quaternion.identity);
            Instantiate(nubeEscogidaSuperior2, posNubeSuperior2, Quaternion.identity);
            Instantiate(nubeEscogidaInferior2, posNubeInferior2, Quaternion.identity);
            
            i += distanciaEntreNubes;
        }
    }
}
