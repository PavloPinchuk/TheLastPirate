using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;

public class Enemy : MonoBehaviour
{

    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 100f;
    [SerializeField] TextMeshProUGUI enemyHPText;
    public Rigidbody2D rb;
    //bool trigger = false;
    private bool isSee = false;
    public float rotationSpeed = 1f;
    public AudioSource enemyGetHitSound;
    public AudioSource enemyDeathSound;
    private Coroutine attackCoroutine = null;
    public static float staticDamage = -1f;
    public float damage = 2f;

    public Transform destroyArea;

    //public bool arenaMode = false;
    //bool attackCoroutineStarted = false;
    //public float seeDistance = 10f;


    private void OnEnable()
    {
        //Invoke("Disable", 2f);
        health = maxHealth;
        enemyHPText.text = $"{health}";

        if(staticDamage > 0)
        {
            damage = staticDamage;
        }
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
            //float distance_between = (float)Math.Sqrt(Math.Pow((GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x), 2)
            //+ Math.Pow((GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y), 2));
            if (Time.timeScale != 0 && isSee)
            {
                transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0.07f);
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
        enemyGetHitSound.Play();

        if (health <= 0)
        {
            OnEnemyKilled?.Invoke(this);
            health = maxHealth;
            enemyHPText.text = $"{health}";
            enemyDeathSound.Play();
            //if (arenaMode)
            //{
            gameObject.transform.position = destroyArea.position;
            Destroy(gameObject, 1.0f);
            //}
            //else
            //{
            //    gameObject.SetActive(false);
            //}
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                //trigger = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                //StopCoroutine(Attack(other));
                StopCoroutine(attackCoroutine);
                
                //trigger = false;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                //trigger = true;
                //while (trigger && Time.timeScale != 0)
                //{
                //    //other.gameObject.GetComponent<PlayerStats>().GetDamage(1f);


                //    //enemyGetHitSound.Play();
                //    //await
                //    //Task.Delay(TimeSpan.FromSeconds(1));
                //}

                attackCoroutine = StartCoroutine(Attack(other));
                
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

    IEnumerator Attack(Collider2D other)
    {
        
        while (true)
        {
            
            yield return new WaitForSeconds(1);
            if (other.gameObject.GetComponent<PlayerStats>().isLive == true)
            {
                other.gameObject.GetComponent<PlayerStats>().GetDamage(damage);
                enemyGetHitSound.Play();
            }
        }
        //StopCoroutine(Attack(other));

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
