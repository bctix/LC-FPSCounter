using BepInEx;
using FPSCounter.Patches;

namespace FPSCounter.Config
{
    class PersistantCounter
    {
        public static BepInEx.Configuration.ConfigEntry<PersistentCounterColors> Color;
        public static BepInEx.Configuration.ConfigEntry<PersistentCounterFonts> Font;
        public static BepInEx.Configuration.ConfigEntry<int> Size;
        public static BepInEx.Configuration.ConfigEntry<int> XPosition;
        public static BepInEx.Configuration.ConfigEntry<int> YPosition;

        public static BepInEx.Configuration.ConfigEntry<float> R;
        public static BepInEx.Configuration.ConfigEntry<float> G;
        public static BepInEx.Configuration.ConfigEntry<float> B;

        public static void init(BepInEx.Configuration.ConfigFile Config)
        {
            Color = Config.Bind("Persistant Counter", "PersistentCounterColor", PersistentCounterColors.green, "The color of the persistent counter.");
            Color.SettingChanged += (obj, args) =>
            {
                FPSCounterGUI.UpdateGUIColor();
            };

            Font = Config.Bind("Persistant Counter", "PersistentCounterFont", PersistentCounterFonts.arial, "The Font of the persistent counter.");
            Font.SettingChanged += (obj, args) =>
            {
                FPSCounterGUI.UpdateGUIFont();
            };

            Size = Config.Bind("Persistant Counter", "PersistentCounterSize", 24, "The Size of the persistent counter. The max is 500");
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

            R = Config.Bind("Persistant Counter Color", "PersistentCounterColorR", 255f, "The R Value of the persistent counter");
            G = Config.Bind("Persistant Counter Color", "PersistentCounterColorG", 255f, "The G Value of the persistent counter");
            B = Config.Bind("Persistant Counter Color", "PersistentCounterColorB", 255f, "The B Value of the persistent counter");

            BepInEx.Configuration.ConfigEntry<float>[] colors = { R, G, B };

            foreach (var setting in colors)
            {
                setting.SettingChanged += (obj, args) =>
                {
                    if (setting.Value > 255)
                        setting.Value = 255;
                    if (setting.Value < 0)
                        setting.Value = 0;

                    Config.Save();
                    FPSCounterGUI.UpdateGUIColor();
                };
            }
        }

        public enum PersistentCounterColors
        {
            green,
            blue,
            red,
            yellow,
            white,
            cyan,
            custom
        }

        public enum PersistentCounterFonts
        {
            arial,
            montserrat,
            impact,
            sans,
            papyrus,
            standard_galactic,
            braille
        }
    }
}