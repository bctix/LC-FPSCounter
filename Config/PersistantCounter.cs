using BepInEx;
using FPSCounter.Patches;

namespace FPSCounter.Config
{
    class PersistantCounter
    {
        public static BepInEx.Configuration.ConfigEntry<PersistentCounterColors> Color;
        public static BepInEx.Configuration.ConfigEntry<int> Size;
        public static BepInEx.Configuration.ConfigEntry<int> XPosition;
        public static BepInEx.Configuration.ConfigEntry<int> YPosition;

        public static void init(BepInEx.Configuration.ConfigFile Config)
        {
            Color = Config.Bind("Persistant Counter", "PersistentCounterColor", PersistentCounterColors.green, "The color of the persistent counter.");
            Color.SettingChanged += (obj, args) =>
            {
                FPSCounterGUI.UpdateGUIColor();
            };

            Size = Config.Bind("Persistant Counter", "PersistentCounterSize", 24, "The color of the persistent counter. The max is 500");
            Size.SettingChanged += (obj, args) =>
            {
                if(Size.Value > 500)
                {
                    Size.Value = 500;
                    Config.Save();
                }
                if (Size.Value < 1)
                {
                    Size.Value = 1;
                    Config.Save();
                }
                FPSCounterGUI.UpdateGUISize();
            };

            XPosition = Config.Bind("Persistant Counter", "PersistentCounterXPosition", 10, "The X Position of the persistent counter");
            YPosition = Config.Bind("Persistant Counter", "PersistentCounterYPosition", 10, "The Y Position of the persistent counter");
        }

        public enum PersistentCounterColors
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