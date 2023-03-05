using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float damage = 25f;

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
            case "Enemy":
                other.gameObject.GetComponent<Enemy>().GetDamage(damage);
                gameObject.SetActive(false);
                break;
            case "EnemyShooter":
                other.gameObject.GetComponent<EnemyShooter>().GetDamage(damage);
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
