using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerP : MonoBehaviour
{
    /*Sentimientos*/
    Dictionary<int, List<float>> sistemaSentimientos = new Dictionary<int, List<float>>();
    static public float fuerzaActualPlayer;

    /*Adicional*/
    private Rigidbody2D rb;
    private bool mirarDerecha = true;

    /*Vida y Energia*/
    [Header("Vida y Energia")]
    [SerializeField] private int mapeoSentimiento;
    [SerializeField] private float vida;
    [SerializeField] private float energia;

    /*Caminar, Correr y Dash*/
    [Header("Caminar, Correr y Dash")]
    [SerializeField] private float veloCaminar;
    [SerializeField] private float veloAdicCorrer; // correr: se SUMA la velocidad adicional
    [SerializeField] private float velocidadDash;
    private float duracionDash;        // cuanto dura el dash
    [SerializeField] private float inicioTiempoDash;    // variable para finalizar el dash (tiempo)
    private float inputMovimiento;
    private float velocidadMovimientoInicial;
    private int direccion;
    private bool permitirDash = true;

    /*Salto y Gravedad*/
    [Header("Salto y Gravedad")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float fuerzaAdicSalto;
    [SerializeField] public float numSaltosExtra;
    [SerializeField] private float gravedadJugador;  // se modifica segun el sentimiento
    private float gravedadInicial;
    [SerializeField] private float radioChequeo;
    [SerializeField] private LayerMask cualEsPiso;
    [SerializeField] private Transform chequearPiso;
    private bool estaEnPiso;
    private float saltosExtra;

    /*Extras*/
    [Header("Extras")]
    [SerializeField] private float tiempoSentimiento;
    [SerializeField] private float fuerzaLanzarObjetos;
    [SerializeField] private float timerFuerzaLanzarObjetos;
    [SerializeField] private GameObject roca; // para pruebas
    [SerializeField] private Transform posLanzamiento; // posicion para lanzar objeto 
    [SerializeField] private bool atravesarObjetos;

    /*Canvas*/
    [SerializeField] private Text txtMecanicas;

    /*Animator*/
    Animator animator;
    Controller2D controller;

    /*Oscurdiad*/
    public GameObject oscuridad;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sistemaSentimientos = SentimientosP.SentimientosConfig;
        animator = GetComponent<Animator>();

        /*for (int i = 0; i < Sentimientos.SentimientosConfig.Count; i++)
        {
            for (int j = 0; j < Sentimientos.SentimientosConfig[i].Count; j++)
            {
                sistemaSentimientos[i][j] = Sentimientos.SentimientosConfig[i][j];
                Debug.Log(sistemaSentimientos[i][j]);
            }
            Debug.Log("je");
        }*/

        //saltosExtra = numSaltosExtra;

        velocidadMovimientoInicial = veloCaminar;

        //gravedadInicial = rb.gravityScale;

        //duracionDash = inicioTiempoDash;

        //rocaRB = roca.GetComponent<Rigidbody2D>();
        fuerzaActualPlayer = 1;
        mapeoSentimiento = 1;
        CambiarMecanicasSentimientos(mapeoSentimiento);
    }

    void Update()
    {

        //cambiarMecanicasSentimientos(mapeoSentimiento);

        inputMovimiento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputMovimiento * veloCaminar, rb.velocity.y);

        Correr();

        Salto();

        Dash();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.mapeoSentimiento++;
            if (this.mapeoSentimiento == 8)
            {
                this.mapeoSentimiento = 0;
            }
            fuerzaActualPlayer = sistemaSentimientos[mapeoSentimiento][10];
            CambiarMecanicasSentimientos(mapeoSentimiento);
        }

        lanzarObjeto();
        /* OCULTAR OBJETOS OSCURIDAD*/
        if (Input.GetKeyDown(KeyCode.Z) && oscuridad.activeSelf == false)

        {
            oscuridad.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Z) && oscuridad.activeSelf == true)
        {
            oscuridad.SetActive(false);
        }

    }



     
void FixedUpdate()
    {
        verificarPiso();
    }


    void CambiarMecanicasSentimientos(int mapeoSentimiento)
    {
        this.vida = sistemaSentimientos[mapeoSentimiento][0];
        this.energia = sistemaSentimientos[mapeoSentimiento][1];
        this.velocidadMovimientoInicial = sistemaSentimientos[mapeoSentimiento][2];
        this.veloAdicCorrer = sistemaSentimientos[mapeoSentimiento][3];
        this.velocidadDash = sistemaSentimientos[mapeoSentimiento][4];
        this.fuerzaSalto = sistemaSentimientos[mapeoSentimiento][5];
        this.fuerzaAdicSalto = sistemaSentimientos[mapeoSentimiento][6];
        this.numSaltosExtra = sistemaSentimientos[mapeoSentimiento][7];
        this.gravedadInicial = sistemaSentimientos[mapeoSentimiento][8];
        this.gravedadJugador = sistemaSentimientos[mapeoSentimiento][8];
        if (sistemaSentimientos[mapeoSentimiento][9] == 1)
            this.atravesarObjetos = true;
        else this.atravesarObjetos = false;
        this.fuerzaLanzarObjetos = sistemaSentimientos[mapeoSentimiento][10];
        this.tiempoSentimiento = sistemaSentimientos[mapeoSentimiento][11];

        txtMecanicas.text = "vida " + sistemaSentimientos[mapeoSentimiento][0] + '\n' + "energia " + sistemaSentimientos[mapeoSentimiento][1] + '\n' + "caminar " + sistemaSentimientos[mapeoSentimiento][2] + '\n' + "+ correr " + sistemaSentimientos[mapeoSentimiento][3] + '\n' + "+ dash " + sistemaSentimientos[mapeoSentimiento][4] + '\n' + "fuerza salto " + sistemaSentimientos[mapeoSentimiento][5] + '\n' + "+ salto adicional " + sistemaSentimientos[mapeoSentimiento][6] + '\n' + "+ num saltos " + sistemaSentimientos[mapeoSentimiento][7] + '\n' + "gravedad " + sistemaSentimientos[mapeoSentimiento][8] + '\n' + "interactuar con objetos " + sistemaSentimientos[mapeoSentimiento][9] + '\n' + "fuerza lanzamiento objetos " + sistemaSentimientos[mapeoSentimiento][10] + '\n' + "timer por sentimientos " + sistemaSentimientos[mapeoSentimiento][11] + '\n';
        Debug.Log(sistemaSentimientos[mapeoSentimiento][0]); 
        Debug.Log(sistemaSentimientos[mapeoSentimiento][1]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][2]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][3]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][4]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][5]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][6]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][7]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][8]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][9]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][10]);
        Debug.Log(sistemaSentimientos[mapeoSentimiento][11]);
    }

    void RotarSprite()
    {
        mirarDerecha = !mirarDerecha;
        Vector3 rotacion = transform.localScale;
        rotacion.x *= -1;
        this.transform.localScale = rotacion;
    }

    void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            veloCaminar = velocidadMovimientoInicial + veloAdicCorrer;
            rb.gravityScale = gravedadJugador;// modificar la variable dependiendo del sentimiento
        }
        else
        {
            veloCaminar = velocidadMovimientoInicial;
            rb.gravityScale = gravedadInicial;
        }

       
    }

    void Salto()
    {
        
        if (estaEnPiso == true)
        {
            saltosExtra = numSaltosExtra;
        }
        if (Input.GetKeyDown(KeyCode.Space) && saltosExtra > 0)
        {
            rb.velocity = Vector2.up * (fuerzaSalto + fuerzaAdicSalto);
            saltosExtra--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && saltosExtra == 0 && estaEnPiso == true)
        {
            rb.velocity = Vector2.up * (fuerzaSalto + fuerzaAdicSalto);
        }
    }

    void Dash()
    {
        /*if(rb.velocity == Vector2.zero)
        {
            permitirDash = true;
        }*/

        /*if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            permitirDash = true;
        }*/

        /*if(permitirDash)
            {
                if (duracionDash <= 0)
                {
                    duracionDash = inicioTiempoDash;
                    Debug.Log("if " + duracionDash);
                }
                else
                {
                    duracionDash -= Time.deltaTime;
                    Debug.Log("else " + duracionDash);
                    if (inputMovimiento > 0) rb.velocity = new Vector2(velocidadMovimiento * velocidadDash, rb.velocity.y);
                    else if (inputMovimiento < 0)
                        rb.velocity = new Vector2(-1 * velocidadMovimiento * velocidadDash, rb.velocity.y);
                }
            }
            permitirDash = false;*/

    }

    void verificarPiso()
    {
        estaEnPiso = Physics2D.OverlapCircle(chequearPiso.position, radioChequeo, cualEsPiso);

        if (mirarDerecha == false && inputMovimiento > 0)
        {

            RotarSprite();
        }
        else if (mirarDerecha == true && inputMovimiento < 0)
        {
            RotarSprite();
        }
    }

    void lanzarObjeto()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timerFuerzaLanzarObjetos = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            float tiempoApretado = Time.time - timerFuerzaLanzarObjetos;
            Instantiate(roca, posLanzamiento.transform.position, posLanzamiento.transform.rotation);
        }

    }
}
