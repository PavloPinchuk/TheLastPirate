using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyToggle : MonoBehaviour
{
    public Toggle easy;
    public Toggle normal;
    public Toggle hard;
    public Button ok;
    //public static Difficulty difficulty;

    public static event Action<DifficultyToggle> OnDifficultyChanged;

    private void Start()
    {
        ok.onClick.AddListener(GetDifficulty);
    }

    public void GetDifficulty()
    {
        GameManagerArena.difficulty = Difficulty.Easy;
        if (hard.isOn)
        {
            GameManagerArena.difficulty = Difficulty.Hard;
        }
        if (normal.isOn)
        {
            GameManagerArena.difficulty = Difficulty.Normal;
        }
        if (easy.isOn)
        {
            GameManagerArena.difficulty = Difficulty.Easy;
        }
    }

}
