using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptDialogueLevel1_2 : MonoBehaviour
{
    public Button btnNext;
    public Text _text;
    private int number;

    public static event Action<ScriptDialogueLevel1_2> OnDialogEnd;

    void Start()
    {
        number = 1;
        Time.timeScale = 0;
        btnNext.onClick.AddListener(Next);
    }

    void Next()
    {
        var res = "";
        switch(number)
        {
            case 1:
                {
                    res = "Morty: What kind of creatures are these?";
                    break;
                }
            case 2:
                {
                    res = "???: Agrrrrr!!!";
                    break;
                }
            case 3:
                {
                    res = "Morty: Hey, give me my bottle!";
                    break;
                }

            default:
                {
                    //GameObject.FindGameObjectWithTag("CanvasDialogueLevel1_2").SetActive(false);
                    Time.timeScale = 1;
                    OnDialogEnd?.Invoke(this);
                    break;
                }
        }
        _text.text = res;
        number++;
    }
}
