using LethalConfig;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace FPSCounter.Compatibility
{
    class LethalConfig
    {
        public static void init()
        {
            FPSCounterBase.debugLog("Lethal Config spotted, loading LCManager stuff");
            var DisableBox = new BoolCheckBoxConfigItem(Config.General.disableFPS, new BoolCheckBoxOptions()
            {
                RequiresRestart = false,
                Name = "Disable Counter"
            });
            LethalConfigManager.AddConfigItem(DisableBox);

            var PersistantCounterBox = new BoolCheckBoxConfigItem(Config.General.persistentCounter, new BoolCheckBoxOptions()
            {
                RequiresRestart = false,
                Name = "Persistant Counter"
            });
            LethalConfigManager.AddConfigItem(PersistantCounterBox);

            var PersistantCounterColor = new EnumDropDownConfigItem<Config.PersistantCounter.PersistentCounterColors>(Config.PersistantCounter.Color, new EnumDropDownOptions()
            {
                RequiresRestart = false,
                Name = "Color"
            });
            LethalConfigManager.AddConfigItem(PersistantCounterColor);

            var PersistantCounterFont = new EnumDropDownConfigItem<Config.PersistantCounter.PersistentCounterFonts>(Config.PersistantCounter.Font, new EnumDropDownOptions()
            {
                RequiresRestart = false,
                Name = "Font"
            });
            LethalConfigManager.AddConfigItem(PersistantCounterFont);

            var PersistantCounterSize = new IntSliderConfigItem(Config.PersistantCounter.Size, new IntSliderOptions() {
                Min = 1,
                Max = 500,
                RequiresRestart = false,
                Name = "Font Size"
            });
            LethalConfigManager.AddConfigItem(PersistantCounterSize);

            

            var PersistantCounterXPosition = new IntInputFieldConfigItem(Config.PersistantCounter.XPosition, new IntInputFieldOptions()
            {
                Min = -10000,
                Max = 10000,
                RequiresRestart = false,
                Name = "X Position"
            });
            LethalConfigManager.AddConfigItem(PersistantCounterXPosition);

            var PersistantCounterYPosition = new IntInputFieldConfigItem(Config.PersistantCounter.YPosition, new IntInputFieldOptions()
            {
                Min = -10000,
                Max = 10000,
                RequiresRestart = false,
                Name = "Y Position"
            });
            LethalConfigManager.AddConfigItem(PersistantCounterYPosition);

            var PersistantCounterR = new FloatSliderConfigItem(Config.PersistantCounter.R, new FloatSliderOptions()
            {
                Min = 1,
                Max = 255,
                RequiresRestart = false,
                Name = "R"
            });

            

            var PersistantCounterG = new FloatSliderConfigItem(Config.PersistantCounter.G, new FloatSliderOptions()
            {
                Min = 1,
                Max = 255,
                RequiresRestart = false,
                Name = "G"
            });

            var PersistantCounterB = new FloatSliderConfigItem(Config.PersistantCounter.B, new FloatSliderOptions()
            {
                Min = 1,
                Max = 255,
                RequiresRestart = false,
                Name = "B"
            });

            LethalConfigManager.AddConfigItem(PersistantCounterR);
            LethalConfigManager.AddConfigItem(PersistantCounterG);
            LethalConfigManager.AddConfigItem(PersistantCounterB);

        }
    }

    
}
