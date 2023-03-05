using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;

public class EnemyShooter : MonoBehaviour
{

    public static event Action<EnemyShooter> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 100f;
    [SerializeField] TextMeshProUGUI enemyHPText;
    public Rigidbody2D rb;
    bool trigger = false;
    public GameObject weapon;

    private bool isSee = false;
    public float rotationSpeed = 1f;
    public AudioSource enemyAtackSound;
    public AudioSource enemyKillSound;


    private void OnEnable()
    {
        //Invoke("Disable", 2f);
        health = maxHealth;
        enemyHPText.text = $"{health}";
    }

    private void Start()
    {
        health = maxHealth;
        enemyHPText.text = $"{health}";
    }

    public void attack(bool see)
    {
        isSee = see;
    }

    private void FixedUpdate()
    {
        try
        {
            if (Time.timeScale != 0 && isSee)
            {
                weapon.GetComponent<EnemyWeapon>().Fire();
                transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0.09f);
                var dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * Time.deltaTime * rotationSpeed);
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }


    public void GetDamage(float damageAmount)
    {
        health -= damageAmount;
        enemyHPText.text = $"{health}";

        if (health <= 0)
        {
            
            OnEnemyKilled?.Invoke(this);
            health = maxHealth;
            enemyHPText.text = $"{health}";
            if (enemyKillSound.isActiveAndEnabled)
            {
                enemyKillSound.Play();
            }
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                trigger = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                trigger = false;
                break;
        }
    }

    async void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                trigger = true;
                while (trigger && Time.timeScale != 0)
                {
                    other.gameObject.GetComponent<PlayerStats>().GetDamage(1f);
                    enemyAtackSound.Play();
                    await
                    Task.Delay(TimeSpan.FromSeconds(1));
                }
                break;

                //case "Wall":
                //    trigger = true;
                //    while (trigger)
                //    {
                //        transform.position = Vector2.MoveTowards(transform.position, -other.transform.position, 0.3f);
                //        await
                //        Task.Delay(TimeSpan.FromSeconds(1));
                //    }
                //    break;


        }
    }


    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
