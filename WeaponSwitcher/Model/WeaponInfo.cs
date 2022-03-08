using Gear;
using Player;

namespace WeaponSwitcher.Model
{
    public class WeaponInfo : InventorySlotAmmo
    {
        public WeaponInfo(GearIDRange gearId, int ammunitionInMagazine, InventorySlotAmmo inventorySlotAmmo) : base()
        {
            GearId = gearId;
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

        public GearIDRange GearId { get; set; }
        public int AmmunitionInMagazine { get; set; }
    }
}
