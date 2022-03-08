using Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponSwitcher.Model
{
    public class WeaponStatus
    {
        public WeaponStatus()
        { }

        public uint GearId { get; set; }

        public AmmoType Type { get; set; }
        public int MagazineAmmo { get; set; }
        public int AmmoInPack { get; set; }

    }
}
