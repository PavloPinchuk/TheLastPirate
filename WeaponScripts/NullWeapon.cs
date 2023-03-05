using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullWeapon : Weapon
{
    float damage = 0f;
    float fireRate = 1f;
    int ammo = 0;
    bool isEquipped = false;

    public override float Damage { get => damage; set => damage = value; }
    public override float FireRate { get => fireRate; set => fireRate = value; }
    public override int Ammo { get => ammo; set => ammo = value; }
    public override bool IsEquipped { get => isEquipped; set => isEquipped = value; }
    public override WeaponType CurrentWeaponType { get => WeaponType.Null; }

    public override void Fire()
    {

    }
}
