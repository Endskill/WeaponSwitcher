using System;
using UnityEngine;

namespace WeaponSwitcher.Script
{
    public class WeaponWheel : MonoBehaviour
    {
        public WeaponWheel(IntPtr intPtr) : base(intPtr)
        { }

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
