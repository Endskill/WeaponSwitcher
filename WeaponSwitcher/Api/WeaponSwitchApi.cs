using GameData;
using Gear;
using Player;
using System;
using WeaponSwitcher.Manager;
using WeaponSwitcher.Model;
using static Player.PlayerBackpack;

namespace WeaponSwitcher.Api
{
    public static class WeaponSwitchApi
    {
        //public static WeaponInfo GetCurrentWeaponInSlot(InventorySlot inventorySlot)
        //{
        //    var localBackPack = PlayerBackpackManager.LocalBackpack;
        //    var backPackItem = GetBackPackItem(localBackPack, inventorySlot);
        //    //TODO Add functionality to change tool or even Throwables. 
        //    GetBulletWeapon(backPackItem, out var bulletWeapon);

        //    var inventorySlotAmmo = localBackPack.AmmoStorage.m_ammoStorage[(int)bulletWeapon.AmmoType];
        //    var weaponInfo2 = inventorySlotAmmo.TryCast<WeaponInfo>();
        //    LogManager.Debug($"weaponInfo TryCast returns {(weaponInfo2 is null ? "null" : weaponInfo2.ToString())}");
            
        //    if (inventorySlotAmmo is WeaponInfo weaponInfo)
        //    {
        //        return weaponInfo;
        //    }

        //    LogManager.Debug("Creating new WeaponInfo object, in GetCurrentWeaponInSlot(InventorySlot)");
        //    weaponInfo = new WeaponInfo(backPackItem.GearIDRange, bulletWeapon.GetCurrentClip(), localBackPack.AmmoStorage.GetInventorySlotAmmo(bulletWeapon.AmmoType));
        //    SetAmmoStorage(weaponInfo, localBackPack.AmmoStorage);

        //    return weaponInfo;
        //}

        //public static WeaponInfo GetOldWeaponAndPutNewIntoInventory(WeaponInfo info)
        //{
        //    var oldWeapon = GetCurrentWeaponInSlot(info.Slot);
        //    //Writing the current clip into "oldWeapon" object reference.
        //    SyncronizeWeaponInfoWithEquipedWeapons(out _, out _);
        //    if(oldWeapon is null)
        //    {
        //        throw new NullReferenceException("old weapon from \"GetCurrentWeaponInSlot(...)\" returned null!");
        //    }
        //    PutWeaponIntoInventory(info);
        //    return oldWeapon;
        //}

        //public static void PutWeaponIntoInventory(WeaponInfo info)
        //{
        //    SyncronizeWeaponInfoWithEquipedWeapons(out _, out _);
        //    var localBackPack = PlayerBackpackManager.LocalBackpack;
        //    localBackPack.SpawnAndEquipGearAsync(info.Slot, info.GearId, (delBackpackItemCallback)BackPackItemCreatedCallBack);
        //    SetAmmoStorage(info, localBackPack.AmmoStorage);

        //    void BackPackItemCreatedCallBack(BackpackItem backpackItem)
        //    {
        //        LogManager.Debug("backPackItem Created");
        //        if (GetBulletWeapon(backpackItem, out var bulletWeapon))
        //        {
        //            bulletWeapon.SetCurrentClip(info.AmmunitionInMagazine);
        //            LogManager.Debug($"Setting new clip to {info.AmmunitionInMagazine}");
        //        }

        //        var playerAgent = PlayerManager.GetLocalPlayerAgent();
        //        playerAgent.Sync.WantsToWieldSlot(info.Slot);
        //    }
            
        //}

        //public static void EquipGear(WeaponInfo info)
        //{
        //    WeaponSwitchApi.PutWeaponIntoInventory(info);
        //}

        //public static WeaponInfo EquipGearAndGetOldInfo(WeaponInfo info)
        //{
        //    var returnValue = WeaponSwitchApi.GetOldWeaponAndPutNewIntoInventory(info);

        //    return returnValue;
        //}

        //public static void SyncronizeWeaponInfoWithEquipedWeapons(out WeaponInfo standardWeaponInfo, out WeaponInfo specialWeaponInfo)
        //{
        //    standardWeaponInfo = GetCurrentWeaponInSlot(InventorySlot.GearStandard);
        //    specialWeaponInfo = GetCurrentWeaponInSlot(InventorySlot.GearSpecial);

        //    var localBackPack = PlayerBackpackManager.LocalBackpack;
        //    GetBulletWeapon(GetBackPackItem(localBackPack, InventorySlot.GearStandard), out var standardWeapon);
        //    GetBulletWeapon(GetBackPackItem(localBackPack, InventorySlot.GearSpecial), out var specialWeapon);

        //    LogManager.Debug($"StandardWeapon magazine = {standardWeaponInfo.AmmunitionInMagazine}, SpecialWeapon magazine = {specialWeaponInfo.AmmunitionInMagazine}");
        //    standardWeaponInfo.AmmunitionInMagazine = standardWeapon.m_clip;
        //    specialWeaponInfo.AmmunitionInMagazine = specialWeapon.m_clip;
        //    LogManager.Debug($"StandardWeapon magazine = {standardWeaponInfo.AmmunitionInMagazine}, SpecialWeapon magazine = {specialWeaponInfo.AmmunitionInMagazine}");
        //}

        //private static BackpackItem GetBackPackItem(PlayerBackpack localBackPack, InventorySlot inventorySlot)
        //{
        //    if (!localBackPack.TryGetBackpackItem(inventorySlot, out var backPackItem))
        //    {
        //        LogManager.Error($"API call GetCurrentWeaponInSlot can't find {inventorySlot} in the local Backpack!");
        //        throw new ArgumentException("There is no BackPackItem for the given parameter", nameof(inventorySlot));
        //    }

        //    return backPackItem;
        //}

        ////TODO This can be done by ItemEquippable.SetCurrentClip(int)!
        //private static bool GetBulletWeapon(BackpackItem backPackItem, out BulletWeapon bulletWeapon)
        //{
        //    LogManager.Debug("GetBulletWepaonMethod...");

        //    var test = backPackItem.Instance.Cast<BulletWeapon>();

        //    bulletWeapon = test;
        //    return true;

        //    LogManager.Debug("After cast");
        //    if (!backPackItem.Instance.TryCastTo(out bulletWeapon))
        //    {
        //        LogManager.Message($"Api call GetCurrentWeaponInSlot has found a backpackitem, but it is not of type BulletWeapon!");
        //        return false;
        //    }

        //    return true;
        //}

        private static void SetAmmoStorage(WeaponInfo info, PlayerAmmoStorage storage)
        {
            //storage.m_ammoStorage[(int)info.AmmoType] = info;

            //switch (info.AmmoType)
            //{
            //    case AmmoType.Standard:
            //        storage.StandardAmmo = info;
            //        break;
            //    case AmmoType.Special:
            //        storage.SpecialAmmo = info;
            //        break;
            //}
        }
    }
}
