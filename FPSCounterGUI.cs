using System.Collections;
using UnityEngine;

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
            style.normal.textColor = Color.green;
            style.hover.textColor = Color.green;
            style.fontSize = 24;
            GUI.depth = 2;
            while (true)
            {
                getAverageFPS();
                FPSCounterBase.mls.LogInfo(count);
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
            GUI.Label(new Rect(10, 0, 100, 25), "FPS: " + Mathf.Round(count), style);
        }
    }
}
