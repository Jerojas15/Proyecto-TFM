using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    /*Extras*/
    private Rigidbody2D rb;
    private bool mirarDerecha = true;

    /*Movimiento, Dash y Gravedad*/
    [Header("Movimiento, Correr y Dash")]
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadAdicionalMovimiento; // correr: se SUMA la velocidad adicional
    [SerializeField] private float velocidadDash;
    private float duracionDash;        // cuanto dura el dash
    [SerializeField] private float inicioTiempoDash;    // variable para finalizar el dash (tiempo)
    [SerializeField] private float gravedadJugador;  // se modifica segun el sentimiento
    private float inputMovimiento;
    private float velocidadMovimientoInicial;
    private float gravedadInicial;
    private int direccion;
    private bool permitirDash = true;

    /*Salto*/
    [Header("Salto")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float fuerzaAdicionalSalto;
    [SerializeField] public int saltosExtraValor;
    [SerializeField] private float radioChequeo;
    [SerializeField] private LayerMask cualEsPiso;
    [SerializeField] private Transform chequearPiso;
    private bool estaEnPiso;
    private int saltosExtra;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        saltosExtra = saltosExtraValor;

        velocidadMovimientoInicial = velocidadMovimiento;

        gravedadInicial = rb.gravityScale;

        duracionDash = inicioTiempoDash;
    }

    void Update()
    {

        inputMovimiento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputMovimiento * velocidadMovimiento, rb.velocity.y);

        if (estaEnPiso == true)
        {
            saltosExtra = saltosExtraValor;
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosExtra > 0)
        {
            rb.velocity = Vector2.up * (fuerzaSalto + fuerzaAdicionalSalto);
            saltosExtra--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && saltosExtra == 0 && estaEnPiso == true)
        {
            rb.velocity = Vector2.up * (fuerzaSalto + fuerzaAdicionalSalto);
        }

        /*if(rb.velocity == Vector2.zero)
        {
            permitirDash = true;
        }*/

        if(Input.GetKey(KeyCode.LeftShift))
        {
            
            velocidadMovimiento = velocidadMovimientoInicial + velocidadAdicionalMovimiento;
            rb.gravityScale = gravedadJugador;// modificar la variable dependiendo del sentimiento
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
        else
        {
            velocidadMovimiento = velocidadMovimientoInicial;
            rb.gravityScale = gravedadInicial;
        }

        /*if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            permitirDash = true;
        }*/
    }
        void FixedUpdate()
    {
        estaEnPiso = Physics2D.OverlapCircle(chequearPiso.position, radioChequeo, cualEsPiso);

        if (mirarDerecha == false && inputMovimiento >0)
        {
            RotarSprite();
        }
        else if(mirarDerecha == true && inputMovimiento < 0)
        {
            RotarSprite();
        }

    }
    void RotarSprite()
    {
        mirarDerecha = !mirarDerecha;
        Vector3 rotacion = transform.localScale;
        rotacion.x *= -1;
        this.transform.localScale = rotacion;
    }
}
