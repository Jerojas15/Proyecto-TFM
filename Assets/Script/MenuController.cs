using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject play;
    public GameObject exit;
    public GameObject controls;
    public GameObject back;
    public GameObject controller;

    public void Play()
    {
        SceneManager.LoadScene("Villa");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        controller.SetActive(true);
        play.SetActive(false);
        exit.SetActive(false);
        controls.SetActive(false);
        back.SetActive(true);
    }

    public void Back()
    {
        controller.SetActive(false);
        play.SetActive(true);
        exit.SetActive(true);
        controls.SetActive(true);
        back.SetActive(false);
    }
}
