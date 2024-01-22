using System.Collections;
using UnityEngine;

namespace FPSCounter
{
    class FPSCounterGUI : MonoBehaviour
    {
        public static GUIStyle style;

        [SerializeField] [Range(0f, 1f)] private static float _expSmoothingFactor = 0.1f;
        [SerializeField] private static float _refreshFrequency = 0.4f;

        private static float _timeSinceUpdate = 0f;
        private static float _averageFps = 1f;

        private float count;

        public int XPosition = Config.PersistantCounter.XPosition.Value;
        public int YPosition = Config.PersistantCounter.YPosition.Value;

        private IEnumerator Start()
        {
            style = new GUIStyle();

            UpdateGUIColor();

            style.fontSize = Config.PersistantCounter.Size.Value;
            GUI.depth = 2;
            while (true)
            {
                getAverageFPS();
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void getAverageFPS()
        {
            _averageFps = _expSmoothingFactor * _averageFps + (1f - _expSmoothingFactor) * 1f / Time.unscaledDeltaTime;

            if (_timeSinceUpdate < _refreshFrequency)
            {
                _timeSinceUpdate += Time.deltaTime;
                return;
            }

            count = Mathf.RoundToInt(_averageFps);
        }

        public static void UpdateGUISize()
        {
            FPSCounterBase.debugLog("Updating GUI size to " + Config.PersistantCounter.Size.Value.ToString());
            style.fontSize = Config.PersistantCounter.Size.Value;
        }

        public static void UpdateGUIColor()
        {
            FPSCounterBase.debugLog("Updating GUI color to: " + Config.PersistantCounter.Color.Value.ToString());

            switch (Config.PersistantCounter.Color.Value)
            {
                case Config.PersistantCounter.PersistentCounterColors.green:
                    style.normal.textColor = Color.green;
                    style.hover.textColor = Color.green;
                    break;
                case Config.PersistantCounter.PersistentCounterColors.blue:
                    style.normal.textColor = Color.blue;
                    style.hover.textColor = Color.blue;
                    break;
                case Config.PersistantCounter.PersistentCounterColors.red:
                    style.normal.textColor = Color.red;
                    style.hover.textColor = Color.red;
                    break;
                case Config.PersistantCounter.PersistentCounterColors.white:
                    style.normal.textColor = Color.white;
                    style.hover.textColor = Color.white;
                    break;
                case Config.PersistantCounter.PersistentCounterColors.cyan:
                    style.normal.textColor = Color.cyan;
                    style.hover.textColor = Color.cyan;
                    break;
                case Config.PersistantCounter.PersistentCounterColors.yellow:
                    style.normal.textColor = Color.yellow;
                    style.hover.textColor = Color.yellow;
                    break;
                default:
                    style.normal.textColor = Color.green;
                    style.hover.textColor = Color.green;
                    break;
            }
        }
        private void OnGUI()
        {
            if(!Config.General.disableFPS.Value && Config.General.persistentCounter.Value)
            {
                GUI.Label(new Rect(Config.PersistantCounter.XPosition.Value, Config.PersistantCounter.YPosition.Value, 100, 25), "FPS: " + Mathf.Round(count), style);
            }
        }
    }
}
