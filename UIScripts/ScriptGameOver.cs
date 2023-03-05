using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptGameOver : MonoBehaviour
{
    public Button btnRestart;
    public Button btnQuit;
    public string loadingScreenName = "Lvl0Loading";

    void Start()
    {
        btnRestart.onClick.AddListener(Restart);
        btnQuit.onClick.AddListener(ToMainMenu);
    }

    public void Restart()
    {
        SceneManager.LoadScene(loadingScreenName);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
