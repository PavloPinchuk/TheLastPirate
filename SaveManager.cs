using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class SaveManager : MonoBehaviour
{
    //public GameManager gm;

    const string healthKey = "healthKey";
    float health = 100;

    const string moneyKey = "moneyKey";
    float money = 0;

    const string currentLevelKey = "currentLevelKey";
    public int currentLevel = 0;

    const string soundValueKey = "soundValueKey";
    float soundValue = 1.0f;

    const string allSoundValueKey = "allSoundValueKey";
    float allSoundValue = 1.0f;

    const string fpsKey = "fpsKey";
    int fps = 60;

    //string path = "data/save.tlps"; // ERROR !!!

    public float Health { get => health; }
    public float Money { get => money; set => money = value; }
    public float SoundValue { get => soundValue; set => soundValue = value; }
    public float AllSoundValue { get => allSoundValue; set => allSoundValue = value; }
    public int FpsValue { get => fps; set => fps = value; }

    public SaveManager(GameManager gm)
    {
        if(gm.ps != null)
        {
            health = gm.ps.getHealth();
            money = gm.ps.getMoney();
        }
    }

    public void Start()
    {
        Load();
    }

    public void Save()
    {

        /*
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            health = gm.ps.getHealth();
            money = gm.ps.getMoney();
            string json = JsonUtility.ToJson(this);
            byte[] buffer = Encoding.Default.GetBytes(json);
            await fs.WriteAsync(buffer, 0, buffer.Length);
        }
        */

        if (currentLevel == 0 || currentLevel == 1)
        {
            PlayerPrefs.SetFloat(healthKey, 100);
        }
        else
        {
            PlayerPrefs.SetFloat(healthKey, health);
        }

        // SETTINGS
        PlayerPrefs.SetFloat(soundValueKey, soundValue);
        PlayerPrefs.SetFloat(allSoundValueKey, allSoundValue);
        PlayerPrefs.SetInt(fpsKey, fps);

        PlayerPrefs.SetFloat(moneyKey, money);
        PlayerPrefs.SetInt(currentLevelKey, currentLevel);
        PlayerPrefs.Save();
        //Debug.Log($"ScriptSettingsScene.cs: Save(): soundValue:{soundValue}");

    }

    public void Load()
    {
        /*
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] buffer = new byte[fs.Length];
            await fs.ReadAsync(buffer, 0, buffer.Length);
            string json = Encoding.Default.GetString(buffer);
            health = JsonUtility.FromJson<SaveManager>(json).Health;
            money = JsonUtility.FromJson<SaveManager>(json).Money;
            gm.ps.setMoney(money);
            gm.ps.setHealth(health);
        }
        */

        soundValue = PlayerPrefs.GetFloat(soundValueKey);
        allSoundValue = PlayerPrefs.GetFloat(allSoundValueKey);
        
        //Debug.Log($"SaveManager.cs: Load(): soundValue:{soundValue}");
        health = PlayerPrefs.GetFloat(healthKey, 100);
        money = PlayerPrefs.GetFloat(moneyKey, 0);
        currentLevel = PlayerPrefs.GetInt(currentLevelKey, 0);
        fps = PlayerPrefs.GetInt(fpsKey, 60);
        //gm.ps.setHealth(health);
        //gm.ps.setMoney(money);
    }

}
