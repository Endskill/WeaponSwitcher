using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Player;
using UnhollowerRuntimeLib;
using WeaponSwitcher.Manager;
using WeaponSwitcher.Model;
using WeaponSwitcher.Script;

namespace WeaponSwitcher
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency(EndskApi.BepInExLoader.GUID, BepInDependency.DependencyFlags.HardDependency)]
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

            ScriptManager.Setup();

            ClassInjector.RegisterTypeInIl2Cpp<WeaponWheel>();
            new Harmony(GUID).PatchAll();
        }
    }
}
