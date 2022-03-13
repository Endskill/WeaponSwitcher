using HarmonyLib;
using WeaponSwitcher.Manager;

namespace WeaponSwitcher.Patches
{
    [HarmonyPatch(typeof(GS_InLevel))]
    public class GS_InLevelPatches
    {
        [HarmonyPatch(nameof(GS_InLevel.Enter))]
        [HarmonyPostfix]
        public static void EnterLevelPostfix()
        {
            ScriptManager.Instance.StartLevelScripts();
        }
    }

    [HarmonyPatch(typeof(GS_AfterLevel))]
    public class GS_AfterLevelPatches
    {
        [HarmonyPatch(nameof(GS_AfterLevel.CleanupAfterExpedition))]
        [HarmonyPrefix]
        public static void EnterLevelPostfix()
        {
            ScriptManager.Instance.EndLevelScripts();
        }
    }
}
