using System;
using System.Collections;
using System.IO;
using System.Reflection;
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

            UpdateGUISize();
            UpdateGUIColor();
            UpdateGUIFont();

            GUI.depth = 2;
            while (true)
            {
                getAverageFPS();
                yield return new WaitForSeconds(0.1f);
            }
        }

        public static void UpdateGUIFont()
        {
            FPSCounterBase.debugLog("Updating GUI font to " + Config.PersistantCounter.Font.Value.ToString());
            style.font = FPSCounterBase.Fonts.LoadAsset<Font>("assets/fonts/"+ Config.PersistantCounter.Font.Value.ToString().Replace("_"," ") + ".ttf");
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

            if(Config.PersistantCounter.Color.Value != Config.PersistantCounter.PersistentCounterColors.custom)
            {
                style.normal.textColor = (Color)typeof(Color).GetProperty(Config.PersistantCounter.Color.Value.ToString()).GetValue(null, null);
                style.hover.textColor = (Color)typeof(Color).GetProperty(Config.PersistantCounter.Color.Value.ToString()).GetValue(null, null);
            } else
            {
                var color = new Color(Config.PersistantCounter.R.Value / 255f, Config.PersistantCounter.G.Value / 255f, Config.PersistantCounter.B.Value / 255f);
                style.normal.textColor = color;
                style.hover.textColor = color;
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
