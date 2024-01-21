using System.Collections;
using UnityEngine;
using System.Reflection;

namespace FPSCounter
{
    class FPSCounterGUI : MonoBehaviour
    {
        private GUIStyle style;

        [SerializeField] [Range(0f, 1f)] private static float _expSmoothingFactor = 0.1f;
        [SerializeField] private static float _refreshFrequency = 0.4f;

        private static float _timeSinceUpdate = 0f;
        private static float _averageFps = 1f;

        private float count;

        private IEnumerator Start()
        {
            style = new GUIStyle();
           switch(Config.General.persistentCounterColor.Value)
           {
                case Config.General.PersistentCounterColor.green:
                    style.normal.textColor = Color.green;
                    style.hover.textColor = Color.green;
                    break;
                case Config.General.PersistentCounterColor.blue:
                    style.normal.textColor = Color.blue;
                    style.hover.textColor = Color.blue;
                    break;
                case Config.General.PersistentCounterColor.red:
                    style.normal.textColor = Color.red;
                    style.hover.textColor = Color.red;
                    break;
                case Config.General.PersistentCounterColor.white:
                    style.normal.textColor = Color.white;
                    style.hover.textColor = Color.white;
                    break;
                case Config.General.PersistentCounterColor.cyan:
                    style.normal.textColor = Color.cyan;
                    style.hover.textColor = Color.cyan;
                    break;
                case Config.General.PersistentCounterColor.yellow:
                    style.normal.textColor = Color.yellow;
                    style.hover.textColor = Color.yellow;
                    break;
                default:
                    style.normal.textColor = Color.green;
                    style.hover.textColor = Color.green;
                    break;
            }
            
            style.fontSize = 24;
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

        private void OnGUI()
        {
            if(!Config.General.disableFPS.Value)
            {
                GUI.Label(new Rect(10, 0, 100, 25), "FPS: " + Mathf.Round(count), style);
            }
        }
    }
}
