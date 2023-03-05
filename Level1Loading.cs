using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Loading : MonoBehaviour
{
    public string sceneLoading = "Lvl0";

    public Coroutine loadLevelCoroutine;
    //public GameObject disableAfterLoading;
    //public Button btnContinue;
    private WaitForSeconds wait;

    void Awake()
    {
        wait = new WaitForSeconds(3);
        //btnContinue.onClick.AddListener(LoadScene);
        //btnContinue.gameObject.SetActive(false);
        loadLevelCoroutine = StartCoroutine(LoadLevelAfterDelay());
    }

    //void LoadScene()
    //{
    //    StopCoroutine(loadLevelCoroutine);
    //    SceneManager.LoadSceneAsync(sceneLoading);
    //}

    IEnumerator LoadLevelAfterDelay()
    {
        yield return wait; // <- ERROR ???
        //disableAfterLoading.SetActive(false);
        //btnContinue.gameObject.SetActive(true);

        SceneManager.LoadSceneAsync(sceneLoading);
    }
}
