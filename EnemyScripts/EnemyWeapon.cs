using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;
    bool trigger = false;
    public AudioSource weaponFireSound;


    public void Fire()
    {
        GameObject projectile = EnemyBulletPooler.Current.GetPooledObject(); //Instantiate(bullet, firePoint.position, firePoint.rotation);
        if (projectile == null) return;
        projectile.transform.position = firePoint.position;
        projectile.transform.rotation = firePoint.rotation;
        projectile.SetActive(true);

        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

        if (weaponFireSound.isActiveAndEnabled)
        {
            weaponFireSound.Play();
        }
        

    }

    //private void OnTriggerStay2D(Collider2D other)
    //{

    //    switch (other.gameObject.tag)
    //    {
    //        case "Enemy":
    //            trigger = true;
    //            break;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    switch (other.gameObject.tag)
    //    {
    //        case "Enemy":
    //            trigger = false;
    //            break;
    //    }
    //}

    //async void OnTriggerEnter2D(Collider2D other)
    //{
    //    switch (other.gameObject.tag)
    //    {
    //        case "Enemy":
    //            trigger = true;
    //            while (trigger)
    //            {
    //                other.gameObject.GetComponent<Enemy>().GetDamage(25f);
    //                await
    //                Task.Delay(TimeSpan.FromSeconds(1));
    //            }

    //            break;
    //    }
    //}
}
