using BepInEx;
using BepInEx.Logging;
using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;
using System.IO;
using System.Reflection;
using System;

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

        public static AssetBundle Fonts;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Hello World!");

            string sAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Fonts = AssetBundle.LoadFromFile(Path.Combine(sAssemblyLocation, "fpsfonts"));
            if (Fonts == null)
            {
                mls.LogError("Failed to load custom assets."); // ManualLogSource for your plugin
                return;
            }

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
