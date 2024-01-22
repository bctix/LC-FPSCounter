using BepInEx;
using FPSCounter.Patches;

namespace FPSCounter.Config
{
    class General
    {
        public static BepInEx.Configuration.ConfigEntry<bool> disableFPS;

        public static BepInEx.Configuration.ConfigEntry<bool> persistentCounter;

        

        public static void init(BepInEx.Configuration.ConfigFile Config)
        {
            disableFPS = Config.Bind("General", "HideCounter", false, "Hides the FPS counter.");
            disableFPS.SettingChanged += (obj, args) =>
            {
                if(disableFPS.Value)
                {
                    if(Patches.HUDPatch._textMesh)
                        Patches.HUDPatch._textMesh.enabled = false;
                } else
                {
                    if (Patches.HUDPatch._textMesh)
                    {
                        if (persistentCounter.Value)
                            Patches.HUDPatch._textMesh.enabled = false;
                        else
                            Patches.HUDPatch._textMesh.enabled = true;
                    }
                }
            };

            persistentCounter = Config.Bind("General", "PersistentCounter", false, "The counter is always showed in the corner, although it can be a bit more intrusive like this.");
            persistentCounter.SettingChanged += (obj, args) =>
            {
                if(persistentCounter.Value)
                {
                    if (Patches.HUDPatch._textMesh)
                        Patches.HUDPatch._textMesh.enabled = false;
                } else
                {
                    if (Patches.HUDPatch._textMesh)
                        Patches.HUDPatch._textMesh.enabled = true;
                }
            };
        }
    }
}