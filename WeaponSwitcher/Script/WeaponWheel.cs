using System;
using System.Collections.Generic;
using UnityEngine;
using WeaponSwitcher.Model;

namespace WeaponSwitcher.Script
{
    public class WeaponWheel : MonoBehaviour
    {
        private List<WeaponInfo> _weaponStandard;
        private List<WeaponInfo> _weaponSpecial;

        public WeaponWheel(IntPtr intPtr) : base(intPtr)
        { 
        
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
