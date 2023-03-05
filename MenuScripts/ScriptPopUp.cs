using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptPopUp : MonoBehaviour
{
    public Button btnOk;

    void Start()
    {
        btnOk.onClick.AddListener(Hide);
    }

    public void Hide()
    {
        GameObject.FindGameObjectWithTag("CanvasPopUp").SetActive(false);
    }
}
