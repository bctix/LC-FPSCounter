using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace FPSCounter
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class FPSCounterBase : BaseUnityPlugin
    {
        private const string modGUID = "bctix.FPSCounter";
        private const string modName = "FPS_Counter";
        private const string modVersion = "1.0.0";

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

            FPSCounter.Config.General.init(Config);

            harmony.PatchAll(typeof(FPSCounterBase));
            harmony.PatchAll(typeof(Patches.HUDPatch));
        }

    }
}
