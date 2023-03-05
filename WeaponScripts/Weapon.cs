using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Null,
    Meele,
    Gun
}

public abstract class Weapon : MonoBehaviour
{
    public static event Action<Weapon> OnFire;
    public abstract float Damage { get; set; }
    public abstract float FireRate { get; set; }
    public abstract int Ammo { get; set; }
    public abstract bool IsEquipped { get; set; }
    public abstract WeaponType CurrentWeaponType { get; }

    public abstract void Fire();
    protected void IvokeOnFire()
    {
        OnFire?.Invoke(this);
    }
    public void AddAmmo(int count)
    {
        if(CurrentWeaponType == WeaponType.Gun)
        {
            Ammo += count;
        }
    }
}
