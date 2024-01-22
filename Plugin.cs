using BepInEx;
using BepInEx.Logging;
using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;

namespace FPSCounter
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("ainavt.lc.lethalconfig", BepInDependency.DependencyFlags.SoftDependency)]
    public class FPSCounterBase : BaseUnityPlugin
    {
        private const string modGUID = "bctix.FPSCounter";
        private const string modName = "FPS_Counter";
        private const string modVersion = "1.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static FPSCounterBase Instance;

        public static ManualLogSource mls;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Hello World!");

            FPSCounter.Config.Config.init(Config);

            //DetectedMods
            var plugins = Chainloader.PluginInfos;
            if(plugins.ContainsKey("ainavt.lc.lethalconfig"))
                Compatibility.LethalConfig.init();

            foreach (var plugin in plugins)
            {
                mls.LogInfo(plugin);
            }
            

            harmony.PatchAll(typeof(FPSCounterBase));
            harmony.PatchAll(typeof(Patches.HUDPatch));
                
        }

        public static void debugLog(object data)
        {
#if DEBUG
            mls.LogInfo(data);
#endif
        }

        private void OnDestroy()
        {
            var FPSGUI = new GameObject("FPSCounterGUI").AddComponent<FPSCounterGUI>();
            DontDestroyOnLoad(FPSGUI);
        }

    }
}
