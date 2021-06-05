using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaP : MonoBehaviour
{
    static public float speed;
    public float tiempoApretado;
    private Rigidbody2D rb;
    [SerializeField] private GameObject destruccionRoca;

    [SerializeField] private GameObject player;
    private float fuerza_inicial;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuerza_inicial = PlayerP.fuerzaActualPlayer;
        Debug.Log("Fuerza de lanzamiento: " + fuerza_inicial);
        var direction = transform.right + Vector3.up;
        rb.AddForce(direction * fuerza_inicial * 5, ForceMode2D.Impulse);

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * fuerza_inicial * Time.deltaTime;
        //this.transform.Translate(Vector3.forward * (this.speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("EnemigoPuente"))
        {
            Destroy(this.gameObject);
            Instantiate(destruccionRoca, this.transform.position, this.transform.rotation);
        }
    }

    public void lanzamiento(float tiempoApretado)
    {
        
    }

}
