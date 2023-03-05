using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Weapon weapon;
    float money = 0f;
    public static event Action<PlayerStats> OnPlayerKilled;
    public static event Action<PlayerStats> OnPlayerGetDamage;
    public static event Action<PlayerStats> OnMoneyCollected;
    public static event Action<PlayerStats> OnWeaponChanged;
    float health = 100f, maxHealth = 100f;
    public AudioSource getHitSound;
    public Rigidbody2D rb;
    public bool isLive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Collectable":
                AddItemToInventory(collision.gameObject);
                collision.gameObject.SetActive(false);
                break;
            case "Weapon":
                if(collision.gameObject.GetComponent<Weapon>().IsEquipped == false)
                {
                    collision.transform.SetParent(gameObject.transform);
                    collision.transform.position = new Vector3(0.1f, 0.1f, 0.1f);
                    collision.gameObject.GetComponent<Weapon>().IsEquipped = true;
                    weapon.gameObject.SetActive(false);
                    weapon = collision.gameObject.GetComponent<Weapon>();
                }
                break;
            case "Money":
                addMoney(collision.gameObject.GetComponent<Money>().value);
                collision.gameObject.SetActive(false);
                break;
        }
    }

    void AddItemToInventory(GameObject gameObject)
    {
        // ...
    }

    private void Start()
    {
        health = maxHealth;
        gameObject.SetActive(true);
    }

    public void addAmmo(int count)
    {
        weapon.AddAmmo(count);
    }

    public float getMoney()
    {
        return money;
    }

    public void addMoney(float x)
    {
        money += x;
        OnMoneyCollected?.Invoke(this);
    }

    public void setMoney(float x)
    {
        money = x;
    }


    public float getHealth()
    {
        return health;
    }

    public void addHealth(float x)
    {
        health += x;
    }

    public void setHealth(float x)
    {
        health = x;
    }

    public void GetDamage(float damageAmount)
    {
        if(isLive == true)
        {
            if (health > 0)
            {
                health -= damageAmount;
                OnPlayerGetDamage?.Invoke(this);
                getHitSound.Play();
            }
            else
            {
                // GAME OVER !
                getHitSound.Stop();
                isLive = false;
                OnPlayerKilled?.Invoke(this);
            }
        }
        else
        {
            // GAME OVER !
            getHitSound.Stop();
            isLive = false;
            OnPlayerKilled?.Invoke(this);
        }

    }
}

