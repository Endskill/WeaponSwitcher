using GameData;
using Gear;
using Player;
using System;
using System.Collections.Generic;
using WeaponSwitcher.Manager;
using WeaponSwitcher.Model;
using static Player.PlayerBackpack;

namespace WeaponSwitcher.Api
{
    public static class WeaponSwitchingApi2
    {
        private static Dictionary<IntPtr, WeaponInfo> _addedWeapons = new Dictionary<IntPtr, WeaponInfo>();

        /// <summary>
        /// Creates a new <see cref="WeaponInfo"/> based on <paramref name="gearId"/>, <paramref name="ammoType"/> and <paramref name="slot"/>.
        /// </summary>
        public static WeaponInfo CreateNewWeaponInfo(InventorySlot slot, AmmoType ammoType, GearIDRange gearId)
        {
            var block = GameDataBlockBase<PlayerDataBlock>.GetBlock(1);

            var slotAmmo = new InventorySlotAmmo();
            slotAmmo.Slot = slot;

            slotAmmo.AmmoInPack = ammoType == AmmoType.Special ? block.AmmoSpecialInitial : block.AmmoStandardInitial;
            slotAmmo.AmmoMaxCap = ammoType == AmmoType.Special ? block.AmmoSpecialMaxCap : block.AmmoStandardMaxCap;

            var weaponInfo = new WeaponInfo(gearId, 0, slotAmmo);

            var gearCategoryBlock = GameDataBlockBase<GearCategoryDataBlock>.GetBlock(gearId.GetCompID(eGearComponent.Category));
            var archetypeId = GearBuilder.GetArchetypeID(gearCategoryBlock, (eWeaponFireMode)gearId.GetCompID(eGearComponent.FireMode));
            var archeTypeBlock = GameDataBlockBase<ArchetypeDataBlock>.GetBlock(archetypeId);
            weaponInfo.InventorySlotAmmo.BulletClipSize = archeTypeBlock.DefaultClipSize;
            weaponInfo.AmmunitionInMagazine = archeTypeBlock.DefaultClipSize;
            LogManager.Debug($"Putting {weaponInfo.AmmunitionInMagazine} into {gearCategoryBlock.PublicName}");
            return weaponInfo;
        }

        public static void EquipGear(WeaponInfo newInfo, out WeaponInfo oldWepaon)
        {
            AddWeaponInfo(newInfo);
            SyncAmmonitionWithRegisteredWeapon(newInfo.Slot, out oldWepaon);
            EquipGear(newInfo);
        }

        public static void SyncAmmonitionWithRegisteredWeapon(InventorySlot slot, out WeaponInfo changedWeapon)
        {
            //If there is no item, we don't need to update anything ...
            if (TryGetItemEquippableInSlot(slot, out var item) && item != null)
            {
                LogManager.Debug("SyncAmmunitionWithRegisteredWeapon actually found Weapon itemequippable");
                var slotAmmo = PlayerBackpackManager.LocalBackpack.AmmoStorage.GetInventorySlotAmmo(slot);
                if(_addedWeapons.TryGetValue(slotAmmo.Pointer, out changedWeapon))
                {
                    changedWeapon.AmmunitionInMagazine = item.GetCurrentClip();
                    LogManager.Debug($"Updated Ammo to {changedWeapon.AmmunitionInMagazine}, Max is {changedWeapon.InventorySlotAmmo.BulletClipSize}");
                }
            }

            changedWeapon = null;
        }

        public static void AddWeaponInfo(WeaponInfo info)
        {
            if(!_addedWeapons.ContainsKey(info.InventorySlotAmmo.Pointer))
            {
                _addedWeapons.Add(info.InventorySlotAmmo.Pointer, info);
            }
        }

        public static void UnregisterWeapon(WeaponInfo info)
        {
            _addedWeapons.Remove(info.InventorySlotAmmo.Pointer);
        }

        private static void EquipGear(WeaponInfo info)
        {
            var localBackPack = PlayerBackpackManager.LocalBackpack;
            localBackPack.SpawnAndEquipGearAsync(info.Slot, info.GearId, (delBackpackItemCallback)BackPackItemCreatedCallBack);
            SetAmmoStorage(info, localBackPack.AmmoStorage);

            void BackPackItemCreatedCallBack(BackpackItem backpackItem)
            {
                var item = backpackItem.Instance.TryCast<ItemEquippable>();
                if(item != null)
                {
                    item.SetCurrentClip(info.AmmunitionInMagazine);

                    var playerAgent = PlayerManager.GetLocalPlayerAgent();
                    playerAgent.Sync.WantsToWieldSlot(info.Slot);
                }
            }
        }

        private static bool TryGetItemEquippableInSlot(InventorySlot slot, out ItemEquippable? item)
        {
            var localBackpack = PlayerBackpackManager.LocalBackpack;

            if(!localBackpack.TryGetBackpackItem(slot, out var backPackItem))
            {
                item = null;
                return false;
            }

            item = backPackItem.Instance.TryCast<ItemEquippable>();
            return item != null;
        }

        private static void SetAmmoStorage(WeaponInfo info, PlayerAmmoStorage storage)
        {
            storage.m_ammoStorage[(int)info.AmmoType] = info.InventorySlotAmmo;

            switch (info.AmmoType)
            {
                case AmmoType.Standard:
                    storage.StandardAmmo = info.InventorySlotAmmo;
                    break;
                case AmmoType.Special:
                    storage.SpecialAmmo = info.InventorySlotAmmo;
                    break;
            }
        }
    }
}
