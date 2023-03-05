using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptStartGame : MonoBehaviour
{
    public Button btnLevels;
    public Button btnSettings;
    public Button btnAbout;
    public Button btnExit;
    public void Start()
    {
        btnLevels.onClick.AddListener(LevelsLoad);
        btnSettings.onClick.AddListener(SettingsLoad);
        btnAbout.onClick.AddListener(AboutLoad);
        btnExit.onClick.AddListener(ExitGame);
    }
    public void LevelsLoad()
    {
        SceneManager.LoadScene("LevelsScene");
    }
    public void SettingsLoad()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void AboutLoad()
    {
        SceneManager.LoadScene("AboutScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
