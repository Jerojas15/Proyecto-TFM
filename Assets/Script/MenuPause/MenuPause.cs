using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI continuar;
    [SerializeField] private TextMeshProUGUI ajustes;
    [SerializeField] private TextMeshProUGUI menuPrincipal;

    [SerializeField] private TextMeshProUGUI verControles;
    [SerializeField] private TextMeshProUGUI musica;
    [SerializeField] private TextMeshProUGUI sonido;
    [SerializeField] private TextMeshProUGUI atras;

    [SerializeField] private GameObject canvasPausa;
    [SerializeField] private GameObject canvasPausaAjustes;
    [SerializeField] private GameObject hojas;
    [SerializeField] private GameObject hojasSecas;
    [SerializeField] private Transform camara;
    private GameObject hojasDestroy;
    private GameObject hojasSecasDestroy;

    [SerializeField] private GameObject musicaGameObject;
    [SerializeField] private GameObject sonidoGameObject;
    [SerializeField] private Sprite cuadroMarcado;
    [SerializeField] private Sprite cuadroNoMarcado;
    public static bool musicaVolumen;
    public static bool sonidoVolumen;

    private int indexPausa;
    private int indexPausaAjustes;
    Color32 blanco = new Color32(255, 255, 255, 255);
    Color32 normal = new Color32(36, 12, 5, 255);

    public static bool estaPausado;
    public static bool estaPausadoAjustes;

    //[SerializeField] private Animator transicion;

    void Start()
    {
        estaPausado = false;
        estaPausadoAjustes = false;
        indexPausa = 0;
        indexPausaAjustes = 0;
        canvasPausa.SetActive(false);
        canvasPausaAjustes.SetActive(false);

        musicaVolumen = true;
        sonidoVolumen = true;
        Image musicaGO = musicaGameObject.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && estaPausado == false) //&& transicion.GetBool("TransicionActiva")==false)
        {
            Pausar();
        }
        else if(Input.GetKeyDown(KeyCode.P) && estaPausado == true)
        {
            Despausar();
            indexPausa = 0;
        }

        if(estaPausado == true)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                indexPausa++;
                if (indexPausa == 3) indexPausa = 0;
                Debug.Log("index pausa: " + indexPausa);
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                indexPausa--;
                if (indexPausa == -1) indexPausa = 2;
                Debug.Log("index pausa: " + indexPausa);
            }

            switch (indexPausa)
            {
                case 0:
                    continuar.outlineColor = blanco;
                    ajustes.outlineColor = normal;
                    menuPrincipal.outlineColor = normal;
                    break;
                case 1:
                    continuar.outlineColor = normal;
                    ajustes.outlineColor = blanco;
                    menuPrincipal.outlineColor = normal;
                    break;
                case 2:
                    continuar.outlineColor = normal;
                    ajustes.outlineColor = normal;
                    menuPrincipal.outlineColor = blanco;
                    break;
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch (indexPausa)
                {
                    case 0:
                        Despausar();
                        break;
                    case 1:
                        canvasPausa.SetActive(false);
                        canvasPausaAjustes.SetActive(true);
                        estaPausado = false;
                        estaPausadoAjustes = true;
                        break;
                    case 2:
                        SceneManager.LoadScene("Menu"); break;
                }
            }
        }

        if(estaPausadoAjustes == true)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                indexPausaAjustes++;
                if (indexPausaAjustes == 4) indexPausaAjustes = 0;
                Debug.Log("index pausa ajustes: " + indexPausaAjustes);
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                indexPausaAjustes--;
                if (indexPausaAjustes == -1) indexPausaAjustes = 3;
                Debug.Log("index pausa ajustes: " + indexPausaAjustes);
            }

            switch (indexPausaAjustes)
            {
                case 0:
                    verControles.outlineColor = blanco;
                    musica.outlineColor = normal;
                    sonido.outlineColor = normal;
                    atras.outlineColor = normal;
                    break;
                case 1:
                    verControles.outlineColor = normal;
                    musica.outlineColor = blanco;
                    sonido.outlineColor = normal;
                    atras.outlineColor = normal;
                    break;
                case 2:
                    verControles.outlineColor = normal;
                    musica.outlineColor = normal;
                    sonido.outlineColor = blanco;
                    atras.outlineColor = normal;
                    break;
                case 3:
                    verControles.outlineColor = normal;
                    musica.outlineColor = normal;
                    sonido.outlineColor = normal;
                    atras.outlineColor = blanco;
                    break;               
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch (indexPausaAjustes)
                {
                    case 0:
                        //Despausar();
                        break;
                    case 1:
                        if(musicaVolumen == true)
                        {
                            musicaVolumen = false;
                            musicaGameObject.GetComponent<Image>().sprite = cuadroNoMarcado;
                        }
                        else
                        {
                            musicaVolumen = true;
                            musicaGameObject.GetComponent<Image>().sprite = cuadroMarcado;
                        }
                        break;
                    case 2:
                        if (sonidoVolumen == true)
                        {
                            sonidoVolumen = false;
                            sonidoGameObject.GetComponent<Image>().sprite = cuadroNoMarcado;
                        }
                        else
                        {
                            sonidoVolumen = true;
                            sonidoGameObject.GetComponent<Image>().sprite = cuadroMarcado;
                        }
                        break;
                    case 3:
                        indexPausa = 1;
                        indexPausaAjustes = 0;
                        canvasPausa.SetActive(true);
                        canvasPausaAjustes.SetActive(false);
                        estaPausado = true;
                        estaPausadoAjustes = false;
                        break;
                }
            }
        }
    }

    public void Pausar()
    {
        estaPausado = true;
        canvasPausa.SetActive(true);
        indexPausa = 0;
        Time.timeScale = 0f;
        Vector3 nuevaPos = new Vector3(camara.transform.position.x + 3.47f, camara.transform.position.y + 16.08f, camara.transform.position.z + 10f);
        hojasDestroy = Instantiate(hojas, nuevaPos, camara.transform.rotation);
        hojasSecasDestroy = Instantiate(hojasSecas, nuevaPos, camara.transform.rotation);
    }

    public void Despausar()
    {
        estaPausado = false;
        canvasPausa.SetActive(false);
        Time.timeScale = 1f;
        Destroy(hojasDestroy);
        Destroy(hojasSecasDestroy);
    }
}
