using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo_NivelPuente : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform posPlayer;
    [SerializeField] private float velocidadEnemigo;
    [SerializeField] private int vidaEnemigo;

    public bool perseguir = false;
    void Start()
    {
        posPlayer = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(perseguir)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, posPlayer.position, velocidadEnemigo * Time.deltaTime);
        }
        if(vidaEnemigo <= 0)
        {
            Destroy(this.gameObject);
            GeneradorPlataformas.existeEnemigoPuente = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            //Debug.Log("gople");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.transform.CompareTag("Roca"))
        {
            //Debug.Log("gople");
            vidaEnemigo--;
        }
    }
}
