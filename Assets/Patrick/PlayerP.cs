using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerP : MonoBehaviour
{
    public UIElements uiElements;
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
    private float duracionDash = 0.05f;        // cuanto dura el dash
    private float tiempoDash = 1;
    [SerializeField] private float inicioTiempoDash;    // variable para finalizar el dash (tiempo)
    private float inputMovimiento;
    private float velocidadMovimientoInicial;
    private float direccion = 1;
    private bool isDashing;
    private bool permitirDash = true;
    IEnumerator dashCoroutine;

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
    static public bool permitirDisparar;
    [SerializeField] private GameObject roca; // para pruebas
    [SerializeField] private Transform posLanzamiento; // posicion para lanzar objeto 
    [SerializeField] private bool atravesarObjetos;

    /*Canvas*/
    [SerializeField] private Text txtMecanicas;

    /*Animator*/
    Animator animator;
    Controller2D controller;

    /*Oscuridad*/
    public GameObject oscuridad;
    public GameObject oscuridadact;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sistemaSentimientos = SentimientosP.SentimientosConfig;
        animator = GetComponent<Animator>();

        permitirDisparar = false;

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

        if(inputMovimiento != 0)
        {
            direccion = inputMovimiento;
        }

        inputMovimiento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputMovimiento * veloCaminar, rb.velocity.y);

        animator.SetFloat("speedY", Mathf.Abs(rb.velocity.y));
        animator.SetFloat("speedX", Mathf.Abs(rb.velocity.x));
        // animator.SetBool("isWallSliding", inputMovimiento != 0);

        Correr();

        Salto();

        Dash();

        CambioSentimiento();

        lanzarObjeto();

        /* OCULTAR OBJETOS OSCURIDAD*/
        if (Input.GetButtonDown("CambiarMundo") && oscuridadact.activeSelf == false)

        {
            oscuridadact.SetActive(true);
        }
        else if (Input.GetButtonDown("CambiarMundo") && oscuridadact.activeSelf == true)
        {
            oscuridadact.SetActive(false);
        }


    }



     
    void FixedUpdate()
    {
        verificarPiso();
        if(isDashing)
        {
            rb.AddForce(new Vector2(direccion * velocidadDash,0), ForceMode2D.Impulse);
        }
    }

    void CambioSentimiento()
    {
        if (Input.GetButtonDown("SentimientoSiguiente"))
        {
            this.mapeoSentimiento++;
            if (this.mapeoSentimiento == 8)
            {
                this.mapeoSentimiento = 0;
            }
            fuerzaActualPlayer = sistemaSentimientos[mapeoSentimiento][10];
            CambiarMecanicasSentimientos(mapeoSentimiento);
        }
        else if(Input.GetButtonDown("SentimientoAnterior"))
        {
            this.mapeoSentimiento--;
            if (this.mapeoSentimiento == -1)
            {
                this.mapeoSentimiento = 7;
            }
            fuerzaActualPlayer = sistemaSentimientos[mapeoSentimiento][10];
            CambiarMecanicasSentimientos(mapeoSentimiento);
        }
    }

    void CambiarMecanicasSentimientos(int mapeoSentimiento)
    {
        uiElements.changeSentimiento(mapeoSentimiento);
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

        //txtMecanicas.text = "vida " + sistemaSentimientos[mapeoSentimiento][0] + '\n' + "energia " + sistemaSentimientos[mapeoSentimiento][1] + '\n' + "caminar " + sistemaSentimientos[mapeoSentimiento][2] + '\n' + "+ correr " + sistemaSentimientos[mapeoSentimiento][3] + '\n' + "+ dash " + sistemaSentimientos[mapeoSentimiento][4] + '\n' + "fuerza salto " + sistemaSentimientos[mapeoSentimiento][5] + '\n' + "+ salto adicional " + sistemaSentimientos[mapeoSentimiento][6] + '\n' + "+ num saltos " + sistemaSentimientos[mapeoSentimiento][7] + '\n' + "gravedad " + sistemaSentimientos[mapeoSentimiento][8] + '\n' + "interactuar con objetos " + sistemaSentimientos[mapeoSentimiento][9] + '\n' + "fuerza lanzamiento objetos " + sistemaSentimientos[mapeoSentimiento][10] + '\n' + "timer por sentimientos " + sistemaSentimientos[mapeoSentimiento][11] + '\n';
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
        /*Vector3 rotacion = transform.localScale;
        rotacion.x *= -1;
        this.transform.localScale = rotacion;
        Quaternion rotacionLanzamiento = Quaternion.Inverse(posLanzamiento.transform.rotation);
        posLanzamiento.transform.rotation = rotacionLanzamiento;*/
        Quaternion actualRotacion;
        if(mirarDerecha)
        actualRotacion = Quaternion.AngleAxis(0,Vector3.up);
        else
            actualRotacion = Quaternion.AngleAxis(180, Vector3.up);
        transform.rotation = actualRotacion;
    }

    void Correr()
    {
        if (Input.GetButton("Correr"))
        {
            Debug.Log("Corriendo");
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
        if (Input.GetButtonDown("Salto") && saltosExtra > 0)
        {
            rb.velocity = Vector2.up * (fuerzaSalto + fuerzaAdicSalto);
            saltosExtra--;
        }
        else if (Input.GetButtonDown("Salto") && saltosExtra == 0 && estaEnPiso == true)
        {
            animator.SetTrigger("doJump");
            rb.velocity = Vector2.up * (fuerzaSalto + fuerzaAdicSalto);

        }
    }

    void Dash()
    {
        if(Input.GetButtonDown("Dash") && permitirDash == true)
        {
            if(dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = DashCoroutine(duracionDash, tiempoDash);
            StartCoroutine(dashCoroutine);
        }
    }

    void verificarPiso()
    {
        estaEnPiso = Physics2D.OverlapCircle(chequearPiso.position, radioChequeo, cualEsPiso);

        animator.SetBool("isGrounded", estaEnPiso);

        if (mirarDerecha == false && inputMovimiento > 0)
        {

            RotarSprite();
        }
        else if (mirarDerecha == true && inputMovimiento < 0)
        {
            RotarSprite();
        }
    }

    public void activarPiedras()
    {
        permitirDisparar = true;
        uiElements.togglePiedras();
    }

    void lanzarObjeto()
    {
        if(permitirDisparar)
        {
            if (Input.GetButtonDown("Lanzar"))
            {
                timerFuerzaLanzarObjetos = Time.time;
            }
            if (Input.GetButtonUp("Lanzar"))
            {
                float tiempoApretado = Time.time - timerFuerzaLanzarObjetos;
                Instantiate(roca, posLanzamiento.transform.position, posLanzamiento.transform.rotation);
            }
        }
    }

    public void reducirVida(int valor) {
        this.vida -= valor;
        Debug.Log("Hace dano, vida: " + this.vida);
    }

    public void reducirVelocidad(float porcentaje) {
        Debug.Log(1 - (float)(porcentaje / 100));
        this.velocidadMovimientoInicial *= (float)(1 - (float)(porcentaje / 100));
        this.veloAdicCorrer *= (float) (1 - (float)(porcentaje / 100));
    }

    public void restaurarVelocidad() {
        this.velocidadMovimientoInicial = sistemaSentimientos[mapeoSentimiento][2];
        this.veloAdicCorrer = sistemaSentimientos[mapeoSentimiento][3];
    }

    IEnumerator DashCoroutine(float dashDuracion, float dashTiempoCalma)
    {
        isDashing = true;
        permitirDash = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuracion);
        isDashing = false;
        rb.gravityScale = gravedadInicial;
        rb.velocity = new Vector2(velocidadMovimientoInicial,0);
        yield return new WaitForSeconds(dashTiempoCalma);
        permitirDash = true;
    }
}
