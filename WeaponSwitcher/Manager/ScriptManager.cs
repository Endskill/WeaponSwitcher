using UnityEngine;
using WeaponSwitcher.Script;

namespace WeaponSwitcher.Manager
{
    public class ScriptManager
    {
        private GameObject _obj;

        public static ScriptManager Instance { get; private set; }

        public static void Setup()
        {
            Instance = new ScriptManager();
        }

        public void StartLevelScripts()
        {
            if(_obj != null)
            {
                UnityEngine.Object.Destroy(_obj);
                _obj = null;
            }

            _obj = new GameObject("WeaponSwitcher_Endskill");
            _obj.AddComponent<WeaponWheel>();

            UnityEngine.Object.DontDestroyOnLoad(_obj);
        }

        public void EndLevelScripts()
        {
            if (_obj != null)
            {
                UnityEngine.Object.Destroy(_obj);
                _obj = null;
            }
        }
    }
}
