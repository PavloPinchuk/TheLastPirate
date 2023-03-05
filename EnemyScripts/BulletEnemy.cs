using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnEnable()
    {
        Invoke("Disable", 2f);
    }

    //public GameObject impactEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                gameObject.SetActive(false);
                break;
            case "Player":
                other.gameObject.GetComponent<PlayerStats>().GetDamage(5f);
                gameObject.SetActive(false);
                break;
        }
    }

    //public void Impact()
    //{
    //    Instantiate(impactEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}

    void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
