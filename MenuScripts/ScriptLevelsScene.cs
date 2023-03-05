using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptLevelsScene : MonoBehaviour
{
    public Button btnBack;
    public Button btnSand;
    public Button btnGrass;
    public SaveManager sm;

    public void StoryMode()
    {
        sm.Load();
        switch (sm.currentLevel)
        {
            case 0:
                SceneManager.LoadScene("Lvl0");
                break;
            default:
                SceneManager.LoadScene("LvlHub");
                break;
        }
    }

    public void ArenaMode()
    {
        SceneManager.LoadScene("LvlArena");
    }

    public void Start()
    {
        btnBack.onClick.AddListener(BackToMainMenu);
        btnSand.onClick.AddListener(StoryMode);
        btnGrass.onClick.AddListener(ArenaMode);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
