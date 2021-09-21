using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentimientosP : MonoBehaviour
{
    // MAPEO ESTADO:
    private int mundo_oscuridad = 0; // 0: Mundo Oscuridad
    private int estado_normal = 0; // 1: Normal   // antes 1 ahora 0
    private int estado_odio = 1; // 2: Odio       // antes 2 ahora 1
    private int estado_tristeza = 3; // 3: Tristeza
    private int estado_envidia = 4; // 4: Envidia
    private int estado_culpa = 5; // 5: Culpa
    private int estado_rabia = 6; // 6: Rabia
    private int estado_desesperacion = 7; // 7: Desesperación

    // MAPEO
    // 0 = vida
    // 1 = energia
    // 2 = caminar
    // 3 = + correr
    // 4 = + dash
    // 5 = fuerza salto
    // 6 = + salto adicional
    // 7 = + num saltos
    // 8 = gravedad
    // 9 = interactuar con objetos
    // 10 = fuerza lanzamiento objetos
    // 11 = timer por sentimientos
    // 12 = vida max

    static public Dictionary<int, List<float>> SentimientosConfig = new Dictionary<int, List<float>>();
    static public List<float> mundoOscuridad = new List<float>{      20, 50,  4, 2,    0.0075f,  6, 2,     0, 0.5f,  1, 0.5f, 25, 100 }; 
    static public List<float> estadoNormal = new List<float>{        20, 100, 8, 2,    0.005f,  16, 1.5f,  0, 2f,     0, 1,    -1, 100 }; //-1 para infinito
    static public List<float> estadoOdio = new List<float> {         20, 50,  8.5f, 2.5f, 0.005f,  14f, 1,     1, 2,     0, 1.5f,    20, 100 };
    static public List<float> estadoTristeza = new List<float>{      20, 50,  4, 1.5f, 0.008f,   5, 0.75f, 1, 0.5f,  0, 0.5f, 20, 100 };
    static public List<float> estadoEnvidia = new List<float>{       20, 50,  5, 1.5f, 0.0075f,  6, 0.75f, 2, 1.5f,  0, 2,    20, 100 };
    static public List<float> estadoCulpa = new List<float>{         20, 50,  5, 3,    0.005f,   8, 1f,    2, 2,     0, 0.1f, 20, 100 };
    static public List<float> estadoRabia = new List<float>{         20, 50,  5, 4,    0.0075f,  7, 1.25f, 2, 2.5f,  0, 2.5f, 20, 100 };
    static public List<float> estadoDesesperacion = new List<float>{ 20, 50,  8, 2,    0.0025f,  8, 2,     3, 1.25f, 0, 3,    20, 100 };


    void Awake()
    {
        //SentimientosConfig.Add(mundo_oscuridad, mundoOscuridad);
        SentimientosConfig.Add(estado_normal, estadoNormal);
        SentimientosConfig.Add(estado_odio, estadoOdio);
        /* SentimientosConfig.Add(estado_tristeza, estadoTristeza);
        SentimientosConfig.Add(estado_envidia, estadoEnvidia);
        SentimientosConfig.Add(estado_culpa, estadoCulpa);
        SentimientosConfig.Add(estado_rabia, estadoRabia);
        SentimientosConfig.Add(estado_desesperacion, estadoDesesperacion);*/
    }

}
