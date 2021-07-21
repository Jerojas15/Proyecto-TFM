using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxGuardian : MonoBehaviour
{
    public int vida;
    public GameObject pantera;
    public GameObject abeja;
    private float timer;
    public GameObject iniciozona;
    public GameObject finzona;
    public GameObject zonafase2;
    public Sprite SpriteFinal;
    public GameObject vacio;
    public bool FaseFinal;
    public Transform target;
    public float speed;
    public int ffCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        target = finzona.transform;
        vida = 3;
    }

    public GameObject Animal(int vida)
    {
        if (vida == 3)
        {
            return pantera;
        }

        if (vida == 2 )
        {
            return abeja;
        }

        return vacio;
    
    }

    public void ShootObjects()
    {
        float rand;
        try
        {
            if (vida == 3)
            {
                rand = gameObject.transform.position.x - 1f;
            }
            else if (vida == 2)
            {
                gameObject.transform.position = zonafase2.transform.position;
                rand = Random.Range(iniciozona.transform.position.x, finzona.transform.position.x);
            }
            else
            {
                rand = gameObject.transform.position.x;
            }

            Instantiate(Animal(vida), (new Vector3(rand, gameObject.transform.position.y, gameObject.transform.position.z)), Quaternion.identity);


        }
        catch (System.Exception)
        {
            Debug.Log("Objeto de shoot vacio");
        }
       

            }

    // Update is called once per frame
    void Update()
    {
        // Disparando panteras y abjeas en el tiempo 
        timer -= Time.deltaTime;
        if (timer <= 0f && vida>=2)
        {
            ShootObjects();
            timer = 5f;
        }
        else
        {
            FaseFinal = true;
           
        }  
        //disparando panteras y abjeas en el tiempo 

        if (FaseFinal)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFinal;
            gameObject.transform.position = iniciozona.transform.position;
            try
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, target.localPosition, speed * Time.deltaTime);
            }
            catch (System.Exception)
            {
                Debug.Log("Guardiana stuneada");
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sistema de resta de vida
        if (collision.CompareTag("Chuzo"))
        {
            vida -= 1;
        }
        //Sistema de resta de vida

        //Movimiento del personaje en fase final
        if (collision.CompareTag ("Fin"))
        {
            target = iniciozona.transform;
        }
        else if (collision.CompareTag("Inicio"))
        {
            ffCount += 1;
            target = finzona.transform;
        }

        if (ffCount == 3)
        {            
                target = vacio.transform;                  
        }
        //Movimiento del personaje en fase final
    }
}
