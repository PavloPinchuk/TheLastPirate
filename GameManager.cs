using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    //public int targetFrameRate = 60;

    public int EnemyCount = 0;

    public PlayerStats ps;
    //public AudioSource cameraMusic;
    public AudioSource gameOverSound;
    public SaveManager sm;
    public Canvas startCanvas;

    [SerializeField] AudioMixer am;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = targetFrameRate;
        Load();
        
    }

    public void Save()
    {
        sm.Save();
    }

    public void Load()
    {
        sm.Load();
        //cameraMusic.volume = sm.SoundValue;
        SetSounds();
        //Debug.Log($"GameManager.cs: soundValue:{sm.SoundValue}");
        //Debug.Log($"GameManager.cs: cameraMusic.volume:{cameraMusic.volume}");
    }

    private void OnEnable()
    {
        PlayerStats.OnPlayerKilled += HandlePlayerDefeated;
        PortalLevel1.OnPlayerGoThroughPortal += HandlePlayerGoThroughPortal;
    }

    private void HandlePlayerGoThroughPortal(PortalLevel1 obj)
    {
        Save();
    }


    private void OnDisable()
    {
        PlayerStats.OnPlayerKilled -= HandlePlayerDefeated;
        PortalLevel1.OnPlayerGoThroughPortal -= HandlePlayerGoThroughPortal;
    }

    void HandlePlayerDefeated(PlayerStats obj)
    {
        //cameraMusic.Stop();
        am.SetFloat("Music", 0);
        
        gameOverSound.Play();
        try
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
        catch (NullReferenceException)
        {
        }
        
        //UITimer.playing = false;

        // GAME OVER
        //gameOverCanvas.SetActive(true);
    }

    void SetSounds()
    {
        am.SetFloat("Master", Mathf.Log10(sm.AllSoundValue) * 20);
        am.SetFloat("Music", Mathf.Log10(sm.SoundValue) * 20);
    }

    public void SetOneSound(string name, float value)
    {
        am.SetFloat(name, Mathf.Log10(value) * 20);
    }
}
