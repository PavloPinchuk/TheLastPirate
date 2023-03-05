using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

public class GameManagerArena : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI enemiesCounterText;
    //[SerializeField] TextMeshProUGUI playerHPText;
    //[SerializeField] TextMeshProUGUI timerText;
    //int enemiesCounter = 0;
    //int enemiesCounterLast = 0;
    //public int targetFrameRate = 60;

    public EnemySpawner es;
    public PlayerStats ps;
    //public EnemyPooler ep;
    public AudioSource cameraSound;
    public AudioClip gameOverAudioClip;
    public SaveManager sm;

    private Coroutine spawnCoroutine = null;
    private static bool coroutineWorks = false;

    public static Difficulty difficulty;

    private float enemySpawnDelay = 3f;
    private float enemyDamage = 2f;

    [SerializeField] AudioMixer am;

    //public SaveManager saveManager;
    //public GameObject gameOverCanvas;


    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        //es.SpawnEnemy(enemyDamage);
        //saveManager.Load();
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

    public void UpdateDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                enemySpawnDelay = 3f;
                enemyDamage = 2f;
                break;
            case Difficulty.Normal:
                enemySpawnDelay = 2f;
                enemyDamage = 3f;
                break;
            case Difficulty.Hard:
                enemySpawnDelay = 1f;
                enemyDamage = 4f;
                break;
            default:
                enemySpawnDelay = 3f;
                enemyDamage = 2f;
                break;
        }
        Enemy.staticDamage = enemyDamage;
    }

    public void Load()
    {
        sm.Load();
        SetSounds();
    }

    //private async void Update()
    //{
    //    es.SpawnEnemy();
    //    await
    //        Task.Delay(TimeSpan.FromSeconds(1));
    //}

    private void FixedUpdate()
    {
        if (coroutineWorks == false)
        {
            spawnCoroutine = StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        coroutineWorks = true;
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnDelay);
            UpdateDifficulty();
            es.SpawnEnemy(enemyDamage);
        }
    }

    private void OnEnable()
    {
        //Enemy.OnEnemyKilled += HandleEnemyDefeated;
        //PlayerStats.OnPlayerGetDamage += HandlePlayerGetDamage;
        PlayerStats.OnPlayerKilled += HandlePlayerDefeated;
        //MedKit.OnMedKitLooted += HandleMedKitLooted;
    }

    //private void HandleMedKitLooted(MedKit obj)
    //{
    //    UpdatePlayerHPText();
    //}

    private void OnDisable()
    {
        //Enemy.OnEnemyKilled -= HandleEnemyDefeated;
        //PlayerStats.OnPlayerGetDamage -= HandlePlayerGetDamage;
        PlayerStats.OnPlayerKilled -= HandlePlayerDefeated;
        //MedKit.OnMedKitLooted -= HandleMedKitLooted;

        StopCoroutine(spawnCoroutine);
        coroutineWorks = false;
    }

    //private void Awake()
    //{
    //    UpdateEnemiesCounterText();
    //}

    //void HandleEnemyDefeated(Enemy enemy)
    //{
    //    enemiesCounter++;
    //    UpdateEnemiesCounterText();
    //}

    //void HandlePlayerGetDamage(PlayerStats obj)
    //{
    //    UpdatePlayerHPText();
    //}

    void HandlePlayerDefeated(PlayerStats obj)
    {
        cameraSound.Stop();
        cameraSound.PlayOneShot(gameOverAudioClip);
        try
        {
            StopCoroutine(spawnCoroutine);
            UITimer.playing = false;
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
        catch (NullReferenceException)
        {
        }


        // GAME OVER
        //gameOverCanvas.SetActive(true);
    }

    //private void UpdatePlayerHPText()
    //{
    //    if (ps.getHealth() <= 0)
    //    {
    //        playerHPText.text = $"HP: 0";
    //    }
    //    else
    //    {
    //        playerHPText.text = $"HP: {ps.getHealth()}";
    //    }
    //}

    //private void UpdateEnemiesCounterText()
    //{
    //    enemiesCounterText.text = $"Enemies killed: {enemiesCounter}";
    //    if(enemiesCounter - enemiesCounterLast == 4)
    //    {
    //        ep.AddEnemies(1);
    //        enemiesCounterLast += 4;
    //    }

    //}
}
