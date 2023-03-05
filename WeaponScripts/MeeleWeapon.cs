using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MeeleWeapon : Weapon
{
    int ammo = -1;
    public override int Ammo { get => ammo; set => ammo = value; }
    public float fireForce;
    public AudioSource weaponFireSound;
    public float fireRate = 1.0f;
    public override float FireRate { get => fireRate; set => fireRate = value; }
    public float damage = 40f;
    public override float Damage { get => damage; set => damage = value; }
    public float meeleRadius = 1f;

    public override WeaponType CurrentWeaponType { get => WeaponType.Meele; }
    //public bool inMotion = false;
    public Animator anim;

    public bool isEquipped = false;
    public override bool IsEquipped { get => isEquipped; set => isEquipped = value; }

    public Rigidbody2D rb;

    Coroutine fireCoroutine = null;

    async public override void Fire()
    {
        //inMotion = true;

        anim.SetTrigger("Play");
        IvokeOnFire();
        //await Task.Delay(TimeSpan.FromSeconds(fireRate));
        //fireCoroutine = StartCoroutine(FireCoroutine());
        //inMotion = false;

    }

    IEnumerator FireCoroutine(Collider2D other)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            other.gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{

    //    //switch (other.gameObject.tag)
    //    //{
    //    //    case "Enemy":
    //    //        if (!inMotion)
    //    //        {
    //    //            other.gameObject.GetComponent<Enemy>().GetDamage(0);
    //    //        }
    //    //        else
    //    //        {
    //    //            other.gameObject.GetComponent<Enemy>().GetDamage(Damage);
    //    //        }
    //    //        break;
    //    //}

    //    switch (other.gameObject.tag)
    //    {
    //        case "Enemy":
    //            if (!inMotion)
    //            {
    //                other.gameObject.GetComponent<Enemy>().GetDamage(0);
    //            }
    //            else
    //            {
    //                //other.gameObject.GetComponent<Enemy>().GetDamage(damage);
    //                fireCoroutine = StartCoroutine(FireCoroutine(other));

    //                StopCoroutine(fireCoroutine);
    //                inMotion = false;
    //            }
    //                break;
    //        case "EnemyShooter":
    //            if (!inMotion)
    //            {
    //                other.gameObject.GetComponent<EnemyShooter>().GetDamage(0);
    //            }
    //            else
    //            {
    //                //other.gameObject.GetComponent<EnemyShooter>().GetDamage(damage);
    //                fireCoroutine = StartCoroutine(FireCoroutine(other));

    //                inMotion = false;
    //                StopCoroutine(fireCoroutine);
    //            }
    //            break;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                fireCoroutine = StartCoroutine(FireCoroutine(other));
                //other.gameObject.GetComponent<Enemy>().GetDamage(damage);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                StopCoroutine(fireCoroutine);
                //other.gameObject.GetComponent<Enemy>().GetDamage(damage);
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
