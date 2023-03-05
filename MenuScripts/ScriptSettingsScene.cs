using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptSettingsScene : MonoBehaviour
{
    public Button btnBack;
    public Button btnSave;
    public Button btnDeleteStoryProgress;
    public SaveManager sm;
    public GameManager gm;

    public Slider soundSlider;
    public Slider allSoundSlider;

    public Slider fpsSlider;
    public Text fpsText;

    //public Text musicVolume;
    float soundSliderValue;
    float allSoundSliderValue;
    int fpsSliderValue;

    public void Start()
    {
        btnSave.onClick.AddListener(Save);
        btnBack.onClick.AddListener(BackToMainMenu);
        btnDeleteStoryProgress.onClick.AddListener(DeleteStoryProgress);
        sm.Load();

        allSoundSliderValue = sm.AllSoundValue;
        allSoundSlider.value = allSoundSliderValue;

        soundSliderValue = sm.SoundValue;
        soundSlider.value = soundSliderValue;

        fpsSliderValue = sm.FpsValue;
        fpsSlider.value = fpsSliderValue;
        fpsText.text = fpsSliderValue.ToString();
    }

    private void Update()
    {
        soundSliderValue = soundSlider.value;
        allSoundSliderValue = allSoundSlider.value;
        fpsSliderValue = ((int)fpsSlider.value);
        fpsText.text = fpsSliderValue.ToString();

        gm.SetOneSound("Master", allSoundSliderValue);
        gm.SetOneSound("Music", soundSliderValue);

        //musicVolume.text = $"{sm.SoundValue}";
    }

    private void Save()
    {
        sm.SoundValue = soundSliderValue;
        sm.AllSoundValue = allSoundSliderValue;
        sm.FpsValue = fpsSliderValue;
        Application.targetFrameRate = fpsSliderValue;
        sm.Save();
        //Debug.Log($"ScriptSettingsScene.cs: soundSliderValue:{soundSliderValue}");
        //Debug.Log($"ScriptSettingsScene.cs: sm.SoundValue:{sm.SoundValue}");
    }

    private void DeleteStoryProgress()
    {
        sm.currentLevel = 0;
        sm.Money = 0f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
