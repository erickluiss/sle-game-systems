﻿
using System;

using UnityEngine;


namespace SLE.Systems.Weapon
{
    using SLE.Events;
    using SLE.Systems.Weapon.Data;

    public abstract class Weapon : SLEComponent<Weapon>
    {
        internal static Action<Weapon> OnSucessfullFire = wpn => wpn.OnFire();

        internal static event OnObjectChange<Weapon> OnWeaponFire;
        internal static event OnObjectChange<Weapon> OnWeaponReload;

#if UNDER_DEVELOPMENT
        [SerializeField]
        internal WeaponInfo weaponInfo;

        [SerializeField]
        internal AmmoInfo ammoInfo;

        [SerializeField]
        internal Ammo ammo;

        [Space]
        [SerializeField]
        internal Transform firePoint;

        [Space]
        [SerializeField]
        internal LayerMask targetLayer;
#else
        internal WeaponInfo weaponInfo;
        internal AmmoInfo   ammoInfo;
        internal Ammo       ammo;
        internal Transform  firePoint;
        internal LayerMask  targetLayer;
#endif

        protected abstract void OnFire();

        public void Fire()
        {
            OnWeaponFire(this);
        }
        public void Reload()
        {
            OnWeaponReload(this);
        }
        public override string ToString()
        {
            return weaponInfo.name;
        }
    }
}