using Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponSwitcher.Model
{
    public class AmmoInfo : InventorySlotAmmo
    {
        public AmmoInfo(int ammunitionInMagazine, InventorySlotAmmo inventorySlotAmmo) : base()
        {
            AmmunitionInMagazine = ammunitionInMagazine;

            //This way, we don't interfere with the garbage collector.
            AmmoType = inventorySlotAmmo.AmmoType;
            Slot = inventorySlotAmmo.Slot;
            AmmoMaxCap = inventorySlotAmmo.AmmoMaxCap;
            AmmoInPack = inventorySlotAmmo.AmmoInPack;
            BulletsMaxCap = inventorySlotAmmo.BulletsMaxCap;
            BulletClipSize = inventorySlotAmmo.BulletClipSize;
            CostOfBullet = inventorySlotAmmo.CostOfBullet;
            BulletsToRelConv = inventorySlotAmmo.BulletsToRelConv;
            OnBulletsUpdateCallback = inventorySlotAmmo.OnBulletsUpdateCallback;
        }

        public int AmmunitionInMagazine { get; set; }
    }
}
