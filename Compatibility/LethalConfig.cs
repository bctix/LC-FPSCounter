using LethalConfig;
using LethalConfig.ConfigItems;
using LethalConfig.ConfigItems.Options;

namespace FPSCounter.Compatibility
{
    class LethalConfig
    {
        public static void init()
        {
            FPSCounterBase.debugLog("Lethal Config spotted, loading LCManager stuff");
            var DisableBox = new BoolCheckBoxConfigItem(Config.General.disableFPS, false);
            LethalConfigManager.AddConfigItem(DisableBox);

            var PersistantCounterBox = new BoolCheckBoxConfigItem(Config.General.persistentCounter, false);
            LethalConfigManager.AddConfigItem(PersistantCounterBox);

            var PersistantCounterColor = new EnumDropDownConfigItem<Config.PersistantCounter.PersistentCounterColors>(Config.PersistantCounter.Color, false);
            LethalConfigManager.AddConfigItem(PersistantCounterColor);

            var PersistantCounterSize = new IntInputFieldConfigItem(Config.PersistantCounter.Size, new IntInputFieldOptions() {
            Min = 1,
            Max = 500,
            RequiresRestart = false
            });
            LethalConfigManager.AddConfigItem(PersistantCounterSize);

            var PersistantCounterXPosition = new IntInputFieldConfigItem(Config.PersistantCounter.XPosition, false);
            LethalConfigManager.AddConfigItem(PersistantCounterXPosition);

            var PersistantCounterYPosition = new IntInputFieldConfigItem(Config.PersistantCounter.YPosition, false);
            LethalConfigManager.AddConfigItem(PersistantCounterYPosition);
        }
    }

    
}
