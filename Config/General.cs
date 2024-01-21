using BepInEx;
using FPSCounter.Patches;

namespace FPSCounter.Config
{
    class General
    {
        public static BepInEx.Configuration.ConfigEntry<bool> disableFPS;

        public static BepInEx.Configuration.ConfigEntry<bool> persistentCounter;

        public static BepInEx.Configuration.ConfigEntry<PersistentCounterColor> persistentCounterColor;

        public static void init(BepInEx.Configuration.ConfigFile Config)
        {
            disableFPS = Config.Bind("General", "HideCounter", false, "Hides the FPS counter.");

            persistentCounter = Config.Bind("General", "PersistentCounter", false, "The counter is always showed in the corner, although it can be a bit more intrusive like this.");

            persistentCounterColor = Config.Bind("General", "PersistentCounterColor", PersistentCounterColor.green, "The color of the persistent counter.");
        }

        private static void DisableFPS_SettingChanged(object sender, System.EventArgs e)
        {
            HUDPatch._textMesh.enabled = !disableFPS.Value;
        }

        public enum PersistentCounterColor
        {
            green,
            blue,
            red,
            yellow,
            white,
            cyan
        }
    }
}