using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScripted0 : MonoBehaviour
{

    public Rigidbody2D rb;
    //bool trigger = false;
    public float rotationSpeed = 1f;
    public float speed = 0.1f;
    private GameObject currentTarget;
    public GameObject target0;
    public GameObject target1;

    public Animator anim;

    public bool is_pooled = false;


    private void OnEnable()
    {
        //Invoke("Disable", 2f);
    }

    private void Start()
    {
        currentTarget = target0;
    }

    private void FixedUpdate()
    {
        try
        {
            if (Time.timeScale != 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, speed);
                var dir = currentTarget.transform.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward * Time.deltaTime * rotationSpeed);
                anim.SetBool("is_runnig", true);
            }
            else
            {
                anim.SetBool("is_runnig", false);
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject == target0)
        {
            target0.transform.SetParent(this.gameObject.transform);
            target0.transform.position = new Vector3(0.1f, 0.1f, 0.1f);
            //Destroy(target0);
            currentTarget = target1;
        }
        else if (other.gameObject == target1)
        {
            if (is_pooled)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
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
