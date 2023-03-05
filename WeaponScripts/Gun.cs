using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : Weapon
{
    public int ammo = 100;
    public override int Ammo { get => ammo; set => ammo = value;}
    public Bullet bullet;
    public Transform firePoint;
    public float fireForce;
    public float damage = 25f;
    public override float Damage { get => damage; set => damage = value; }
    //bool trigger = false;
    public AudioSource weaponFireSound;
    public float fireRate = 0.4f;
    public override WeaponType CurrentWeaponType { get => WeaponType.Gun; }
    public override float FireRate { get => fireRate; set => fireRate = value; }
    public bool isEquipped = false;
    public override bool IsEquipped { get => isEquipped; set => isEquipped = value; }

    public override void Fire()
    {
        if (ammo > 0)
        {
            bullet = BulletPooler.Current.GetPooledObject();

            Bullet projectile = BulletPooler.Current.GetPooledObject(); //Instantiate(bullet, firePoint.position, firePoint.rotation);
            if (projectile == null) return;
            projectile.damage = this.Damage;
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            projectile.gameObject.SetActive(true);

            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

            if (weaponFireSound.isActiveAndEnabled)
            {
                weaponFireSound.Play();
            }

            ammo--;
        }
        IvokeOnFire();

    }

    public void AddAmmo(int count)
    {
        ammo += count;
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
