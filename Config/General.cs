using BepInEx;
using FPSCounter.Patches;

namespace FPSCounter.Config
{
    class General
    {
        public static BepInEx.Configuration.ConfigEntry<bool> disableFPS;


        public static void init(BepInEx.Configuration.ConfigFile Config)
        {
            disableFPS = Config.Bind("General", "HideCounter", false, "Hides the FPS counter.");
        }

        private static void DisableFPS_SettingChanged(object sender, System.EventArgs e)
        {
            HUDPatch._textMesh.enabled = !disableFPS.Value;
        }
    }
}