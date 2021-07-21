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
    public Sprite Final;
    public GameObject vacio;


    // Start is called before the first frame update
    void Start()
    {
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
            else if (vida == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Final;
                gameObject.transform.position = iniciozona.transform.position;
                rand = gameObject.transform.position.x;
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
        if (timer <= 0f)
        {
            ShootObjects();
            timer = 3f;
        }
        //disparando panteras y abjeas en el tiempo 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chuzo"))
        {

        }
    }
}
