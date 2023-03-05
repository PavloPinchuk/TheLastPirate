using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptTutorial : MonoBehaviour
{
    public Button btnGotIt;

    public void Start()
    {
        Time.timeScale = 0;
        btnGotIt.onClick.AddListener(Resume);
        if(SceneManager.GetActiveScene().name != "Lvl0" && SceneManager.GetActiveScene().name != "LvlArena")
        {
            Time.timeScale = 1;
            GameObject.FindGameObjectWithTag("TutorialCanvas").SetActive(false);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        UITimer.playing = true;
        GameObject.FindGameObjectWithTag("TutorialCanvas").SetActive(false);
    }
}
