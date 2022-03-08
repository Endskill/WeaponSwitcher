using GameData;
using Gear;
using Player;
using System;
using WeaponSwitcher.Manager;
using WeaponSwitcher.Model;

namespace WeaponSwitcher.Api
{
    public static class WeaponSwitchApi
    {
        public static WeaponInfo GetCurrentWeaponInSlot(InventorySlot inventorySlot)
        {
            var localBackPack = PlayerBackpackManager.LocalBackpack;
            if(!localBackPack.TryGetBackpackItem(inventorySlot, out var backPackItem))
            {
                LogManager.Error($"API call GetCurrentWeaponInSlot can't find {inventorySlot} in the local Backpack!");
                throw new ArgumentException("There is no BackPackItem for the given parameter", nameof(inventorySlot));
            }

            if(!backPackItem.Instance.TryCastTo(out BulletWeapon bulletWepaon))
            {
                LogManager.Message($"Api call GetCurrentWeaponInSlot has found a backpackitem, but it is not of type BulletWeapon!");
                return null;
            }

            return new WeaponInfo(backPackItem.GearIDRange, bulletWepaon.GetCurrentClip(), localBackPack.AmmoStorage.GetInventorySlotAmmo(bulletWepaon.AmmoType));
        }

        public static void PutWeaponIntoInventory(WeaponInfo info)
        {
            var localBackPack = PlayerBackpackManager.LocalBackpack;
            localBackPack.SpawnAndEquipGearAsync(info.Slot, info.GearId);
            localBackPack.AmmoStorage.m_ammoStorage[(int)info.AmmoType] = info;

            //BackpackItem backPackItem = null;

            //GearManager.AssembleGearAsync(info.GearId, ItemMode.FirstPerson,
            //    (PlayerBackpack.delBackpackItemCallback)((gearItem =>
            //{
            //    if ((UnityEngine.Object)gearItem != (UnityEngine.Object)null)
            //    {
            //        GearManager.PostIconJobs(info.GearId);
            //        localBackPack.CheckAndCreateBackpackItem(ref backPackItem, info.Slot, gearItem, info.GearId);
            //        PlayerBackpackManager.SetFPSRendering(gearItem.gameObject, true);
            //        backPackItem.IsLoaded = true;
            //        localBackPack.SetupAmmoStorageForItem((Item)gearItem, info.Slot);
            //        //PlayerBackpack.delBackpackItemCallback backpackItemCallback = onBackpackItemCreated;
            //        //if (backpackItemCallback == null)
            //        //    return;
            //        //backpackItemCallback(backPackItem);
            //    }
            //})));
        }

        public static WeaponInfo CreateNewWeaponInfo(InventorySlot slot, AmmoType ammoType, GearIDRange gearId)
        {
            var block = GameDataBlockBase<PlayerDataBlock>.GetBlock(1);

            var slotAmmo = new InventorySlotAmmo();
            slotAmmo.Slot = slot;

            slotAmmo.AmmoInPack = ammoType == AmmoType.Special ? block.AmmoSpecialInitial : block.AmmoStandardInitial;
            slotAmmo.AmmoMaxCap = ammoType == AmmoType.Special ? block.AmmoSpecialMaxCap : block.AmmoStandardMaxCap;

            //TODO Find out where to get magazine ammo
            return new WeaponInfo(gearId, 0, slotAmmo);
        }
    }
}
