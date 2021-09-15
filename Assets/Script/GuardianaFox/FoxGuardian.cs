using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxGuardian : MonoBehaviour
{
    public int vida;
    public GameObject trampfinal;
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
    public GameObject lamento;
    private PlayerP life;
    public string nombreScena;
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

    IEnumerator returne()
    {
        
        yield return new WaitForSeconds(5f);
        ffCount = 0;
        FaseFinal = true;
        speed = 19;
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
                //transform.position = col2ndfase.transform.position;
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
            fase2anim.clip = fase2anim.GetClip("ZorraFASE1");
            fase2anim.Play();
            trampfinal.SetActive(true);
            //gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFinal;
            FaseFinal = true;
           
        }
        else if (vida ==0)
        {
            SceneManager.LoadScene(nombreScena);
            lamento.SetActive(true);
            
            FaseFinal = false;
            fase2anim.clip = fase2anim.GetClip("ZorraFASE1");
            fase2anim.Play();
            


            //gameObject.transform.position = new Vector3(gameObject.transform.position.x + 10f,gameObject.transform.position.y,gameObject.transform.position.z);
        }
        //disparando panteras y abjeas en el tiempo 

        

        if (FaseFinal == true)
        {

            if (ffCount == 3)
            {
                FaseFinal = false;
                speed = 0;
                StartCoroutine(returne());
             }

            if (gameObject.transform.position.x == finzona.transform.position.x)
            {
                ffCount += 1;
                transform.Rotate(Vector3.down * 180);
                target = iniciozona.transform;
            }
            if (gameObject.transform.position.x == iniciozona.transform.position.x)
            {

                transform.Rotate(Vector3.down * 180);
                target = finzona.transform;
            }
                
            transform.position = Vector2.MoveTowards(transform.localPosition, target.position, speed * Time.deltaTime);


        }
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            life.reducirVida(5);
        }
        //Sistema de resta de vida
        //if (collision.gameObject.CompareTag("Chuzo"))
        //{
        //    vida -= 1;
        //    Destroy(collision.gameObject, 3);
        //}
        //Sistema de resta de vida
    }
   
}
