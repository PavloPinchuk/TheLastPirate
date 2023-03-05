using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptPause : MonoBehaviour
{
    public Button btnResume;
    public Button btnPause;
    public Button btnQuit;
    public GameObject pauseScreen;

    void Start()
    {
        //btnRestart.onClick.AddListener(Restart);
        btnQuit.onClick.AddListener(ToMainMenu);
        btnResume.onClick.AddListener(Resume);
        btnPause.onClick.AddListener(Pause);
        pauseScreen.SetActive(false);
    }

    //public void Restart()
    //{
    //    SceneManager.LoadScene("LevelsScene");
    //}

    public void Pause()
    {
        pauseScreen.SetActive(true);
        btnPause.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        btnPause.gameObject.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
