using Gear;
using Player;
using System;
using System.Collections.Generic;
using UnityEngine;
using WeaponSwitcher.Api;
using WeaponSwitcher.Manager;
using WeaponSwitcher.Model;

namespace WeaponSwitcher.Script
{
    public class WeaponWheel : MonoBehaviour
    {
        private int _standardCoutner = 0;
        private int _specialCounter = 0;

        private List<WeaponInfo> _weaponStandard = new List<WeaponInfo>();
        private List<WeaponInfo> _weaponSpecial = new List<WeaponInfo>();

        public WeaponWheel(IntPtr intPtr) : base(intPtr)
        {
            foreach(var gearId in GearManager.GetAllGearForSlot(Player.InventorySlot.GearStandard))
            {
                _weaponStandard.Add(WeaponSwitchingApi2.CreateNewWeaponInfo(Player.InventorySlot.GearStandard, Player.AmmoType.Standard, gearId));
            }

            foreach (var gearId in GearManager.GetAllGearForSlot(Player.InventorySlot.GearSpecial))
            {
                _weaponSpecial.Add(WeaponSwitchingApi2.CreateNewWeaponInfo(Player.InventorySlot.GearSpecial, Player.AmmoType.Special, gearId));
            }
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                _standardCoutner--;
                WeaponSwitchingApi2.EquipGear(_weaponStandard[_standardCoutner], out var oldWeapon);
                if(oldWeapon != null)
                {
                    _weaponStandard[_standardCoutner + 1] = oldWeapon;
                }
            }

            if(Input.GetKeyDown(KeyCode.K))
            {
                _standardCoutner++;
                WeaponSwitchingApi2.EquipGear(_weaponStandard[_standardCoutner], out var oldWeapon);
                if (oldWeapon != null)
                {
                    _weaponStandard[_standardCoutner - 1] = oldWeapon;
                }
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                _specialCounter--;
                WeaponSwitchingApi2.EquipGear(_weaponSpecial[_specialCounter], out var oldWeapon);
                if (oldWeapon != null)
                {
                    _weaponSpecial[_specialCounter + 1] = oldWeapon;
                }
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                _specialCounter++;
                WeaponSwitchingApi2.EquipGear(_weaponSpecial[_specialCounter], out var oldWeapon);
                if (oldWeapon != null)
                {
                    _weaponSpecial[_specialCounter - 1] = oldWeapon;
                }
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                foreach(var standard in _weaponStandard)
                {
                    LogManager.Message($"StandardWeapon has {standard.AmmunitionInMagazine}, MaxSize = {standard.InventorySlotAmmo.BulletClipSize}");
                }
            }
        }
    }
}
