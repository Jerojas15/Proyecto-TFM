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
    public Sprite SpriteFinal;
    public GameObject vacio;
    public GameObject trampolin;
    public GameObject col2ndfase;
    public bool FaseFinal;
    public Transform target;
    public float speed;
    public int ffCount = 0;
    public Animation fase2anim;
    public bool confirm2nd = false;
   // public Animation fase3anim;
   // public Animation golpeanim;


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


    public IEnumerator idle(int segundos)
    {
        
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(segundos);

        fase2anim.clip = fase2anim.GetClip("Zorrafase2Idle");
        fase2anim.Play();

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
                col2ndfase.SetActive(true);
                trampolin.transform.position = new Vector3(col2ndfase.transform.position.x - 10f,trampolin.transform.position.y,trampolin.transform.position.z);

                // darle play animación centro
                
                if (!confirm2nd)
                {
                    fase2anim.clip = fase2anim.GetClip("ZorraFase2");
                    fase2anim.Play();
                    confirm2nd = true;
                    StartCoroutine(idle(2));
                }
                
                rand = Random.Range(iniciozona.transform.position.x, finzona.transform.position.x);
            }
            else
            {
                rand = gameObject.transform.position.x;
            }
            //
            Instantiate(Animal(vida), (new Vector3(rand, gameObject.transform.position.y + 10, gameObject.transform.position.z)), Quaternion.Euler(0f, 180f, 0f));
            
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
        else if (vida==1)
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFinal;
            FaseFinal = true;
           
        }  
        //disparando panteras y abjeas en el tiempo 

        if (FaseFinal == true)
        {

            if (ffCount == 3)
            {  
                target = vacio.transform;
            }

            if (gameObject.transform.position.x == finzona.transform.position.x)
            {
                transform.Rotate(Vector3.down * 180);
                target = iniciozona.transform;
            }
            if (gameObject.transform.position.x == iniciozona.transform.position.x)
            {
                ffCount += 1;
                transform.Rotate(Vector3.down * 180);
                target = finzona.transform;
            }

                transform.localPosition = Vector2.MoveTowards(transform.localPosition, target.localPosition, speed * Time.deltaTime);
            Debug.Log("target "+ target);
           
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Sistema de resta de vida
        if (collision.gameObject.CompareTag("Chuzo"))
        {
            vida -= 1;
            Destroy(collision.gameObject, 3);
        }
        //Sistema de resta de vida
    }
   
}
