using BepInEx.IL2CPP;
using System;
using UnityEngine;
using WeaponSwitcher.Manager;
using WeaponSwitcher.Script;

namespace WeaponSwitcher
{
    public class BepInExLoader : BasePlugin
    {
        public const string
   MODNAME = "WeaponSwitchingApi",
   AUTHOR = "Endskill",
   GUID = AUTHOR + "." + MODNAME,
   VERSION = "1.0.0";

        public override void Load()
        {
            LogManager.SetLogger(Log);
            LogManager._debugMessagesActive = Config.Bind("Dev Settings", "DebugMessages", false, "This settings activates/deactivates debug messages in the console for this specific plugin.").Value;

            EndskApi.Api.InitApi.AddInitCallback(Initialize);
        }

        public void Initialize()
        {
            var gameObj = new GameObject("WeaponSwitcher_Endskill");
            gameObj.AddComponent<WeaponWheel>();

            UnityEngine.Object.DontDestroyOnLoad(gameObj);
        }
    }
}
