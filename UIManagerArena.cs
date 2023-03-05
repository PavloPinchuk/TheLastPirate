using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerArena : MonoBehaviour
{
    public GameManagerArena gm;
    [SerializeField] Text enemiesCounterText;
    [SerializeField] Text playerHPText;
    [SerializeField] Text ammoText;
    [SerializeField] Text moneyText;
    int enemiesCounter = 0;
    int enemiesCounterLast = 0;
    //private EnemyPooler ep;
    private PlayerStats ps;
    public GameObject gameOverCanvas;

    private void Start()
    {
        //ep = gm.ep;
        ps = gm.ps;

        UpdatePlayerAmmoText();
        UpdateEnemiesCounterText();
        UpdatePlayerHPText();
    }

    private void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyDefeated;
        PlayerStats.OnPlayerGetDamage += HandlePlayerGetDamage;
        PlayerStats.OnPlayerKilled += HandlePlayerDefeated;
        PlayerStats.OnMoneyCollected += HandleMoneyCollected;
        MedKit.OnMedKitLooted += HandleMedKitLooted;
        Weapon.OnFire += HandleFire;
        AmmoCrate.OnAmmoCrateLooted += HandleAmmoCrateLooted;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= HandleEnemyDefeated;
        PlayerStats.OnPlayerGetDamage -= HandlePlayerGetDamage;
        PlayerStats.OnPlayerKilled -= HandlePlayerDefeated;
        PlayerStats.OnMoneyCollected -= HandleMoneyCollected;
        MedKit.OnMedKitLooted -= HandleMedKitLooted;
        Weapon.OnFire -= HandleFire;
        AmmoCrate.OnAmmoCrateLooted -= HandleAmmoCrateLooted;
    }

    private void HandleAmmoCrateLooted(AmmoCrate obj)
    {
        UpdatePlayerAmmoText();
    }

    private void UpdatePlayerAmmoText()
    {
        if (ps.weapon.Ammo == -1)
        {
            ammoText.text = $"inf";
        }
        else if (ps.weapon.Ammo < 1)
        {
            ammoText.text = $"0";
        }
        else
        {
            ammoText.text = $"{ps.weapon.Ammo}";
        }
    }

    private void UpdatePlayerHPText()
    {
        if (ps.getHealth() <= 0)
        {
            playerHPText.text = $"0";
        }
        else
        {
            playerHPText.text = $"{ps.getHealth()}";
        }
    }

    private void UpdateEnemiesCounterText()
    {
        enemiesCounterText.text = $"{enemiesCounter}";
        if (enemiesCounter - enemiesCounterLast == 4)
        {
            //ep.AddEnemies(1);
            enemiesCounterLast += 4;
        }

    }

    private void HandleMoneyCollected(PlayerStats obj)
    {
        if (ps.getMoney() >= 0)
        {
            moneyText.text = $"{ps.getMoney()}";
        }
        else
        {
            moneyText.text = $"0";
        }
    }

    private void UpdateMoneyText()
    {

    }

    private void HandleMedKitLooted(MedKit obj)
    {
        UpdatePlayerHPText();
    }

    private void Awake()
    {
        UpdateEnemiesCounterText();
    }

    void HandleEnemyDefeated(Enemy enemy)
    {
        enemiesCounter++;
        UpdateEnemiesCounterText();
    }

    void HandlePlayerGetDamage(PlayerStats obj)
    {
        UpdatePlayerHPText();
    }

    private void HandleFire(Weapon obj)
    {
        UpdatePlayerAmmoText();
    }

    void HandlePlayerDefeated(PlayerStats obj)
    {
        gameOverCanvas.SetActive(true);
    }
}
