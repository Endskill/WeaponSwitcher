using Gear;
using System;
using System.Collections.Generic;
using UnityEngine;
using WeaponSwitcher.Api;
using WeaponSwitcher.Model;

namespace WeaponSwitcher.Script
{
    public class WeaponWheel : MonoBehaviour
    {
        private List<WeaponInfo> _weaponStandard = new List<WeaponInfo>();
        private List<WeaponInfo> _weaponSpecial = new List<WeaponInfo>();

        public WeaponWheel(IntPtr intPtr) : base(intPtr)
        {
            foreach(var gearId in GearManager.GetAllGearForSlot(Player.InventorySlot.GearStandard))
            {
                _weaponStandard.Add(WeaponSwitchApi.CreateNewWeaponInfo(Player.InventorySlot.GearStandard, Player.AmmoType.Standard, gearId));
            }

            foreach (var gearId in GearManager.GetAllGearForSlot(Player.InventorySlot.GearSpecial))
            {
                _weaponSpecial.Add(WeaponSwitchApi.CreateNewWeaponInfo(Player.InventorySlot.GearSpecial, Player.AmmoType.Special, gearId));
            }
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
            }

            if(Input.GetKeyDown(KeyCode.X))
            {

            }
        }

    }
}
