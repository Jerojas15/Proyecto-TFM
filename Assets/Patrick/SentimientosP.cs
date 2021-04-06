﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentimientosP : MonoBehaviour
{
    // MAPEO ESTADO:
    private int mundo_oscuridad = 0; // 0: Mundo Oscuridad
    private int estado_normal = 1; // 1: Normal
    private int estado_tristeza = 2; // 2: Tristeza
    private int estado_odio = 3; // 3: Odio
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

    static public Dictionary<int, List<float>> SentimientosConfig = new Dictionary<int, List<float>>();
    static public List<float> mundoOscuridad = new List<float>{      100, 50,  2, 2,    1,    5, 1,     0, 0.1f,  1, 0.5f, 25 }; 
    static public List<float> estadoNormal = new List<float>{        100, 100, 4, 2,    8,    4, 0.75f, 0, 1,     0, 1,    -1 }; //-1 para infinito
    static public List<float> estadoTristeza = new List<float>{      100, 50,  2, 0.5f, 4,    2, 0.5f,  1, 0.5f,  0, 0.5f, 20 };
    static public List<float> estadoOdio = new List<float>{          100, 50,  5, 0.5f, 9,    5, 1,     1, 2,     0, 1.5f, 20 };
    static public List<float> estadoEnvidia = new List<float>{       100, 50,  3, 0.5f, 5,    3, 0.25f, 5, 1.5f,  0, 2,    20 };
    static public List<float> estadoCulpa = new List<float>{         100, 50,  2, 1f,   6,    2, 0.15f, 2, 1.5f,  0, 0.1f, 20 };
    static public List<float> estadoRabia = new List<float>{         100, 50,  5, 2,    7,    5, 1.25f, 2, 2.5f,  0, 2.5f, 20 };
    static public List<float> estadoDesesperacion = new List<float>{ 100, 50,  6, 2,    10,   6, 2,     3, 1.25f, 0, 3,    20 };


    void Awake()
    {
        SentimientosConfig.Add(mundo_oscuridad, mundoOscuridad);
        SentimientosConfig.Add(estado_normal, estadoNormal);
        SentimientosConfig.Add(estado_tristeza, estadoTristeza);
        SentimientosConfig.Add(estado_odio, estadoOdio);
        SentimientosConfig.Add(estado_envidia, estadoEnvidia);
        SentimientosConfig.Add(estado_culpa, estadoCulpa);
        SentimientosConfig.Add(estado_rabia, estadoRabia);
        SentimientosConfig.Add(estado_desesperacion, estadoDesesperacion);
    }

}
