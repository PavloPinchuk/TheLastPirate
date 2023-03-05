using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptAboutScene : MonoBehaviour
{
    public Button btnBack;
    public void Start()
    {
        btnBack.onClick.AddListener(BackToMainMenu);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
