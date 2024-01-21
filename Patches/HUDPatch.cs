using HarmonyLib;

using TMPro;
using UnityEngine;

namespace FPSCounter.Patches
{

    [HarmonyPatch(typeof(HUDManager))]
    class HUDPatch
    {
        public static TextMeshProUGUI _textMesh;

        [SerializeField] [Range(0f, 1f)] private static float _expSmoothingFactor = 0.1f;
        [SerializeField] private static float _refreshFrequency = 0.4f;

        private static float _timeSinceUpdate = 0f;
        private static float _averageFps = 1f;

        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        static void updateFPS()
        {
            if (!_textMesh)
                CopyValueCounter();

            _averageFps = _expSmoothingFactor * _averageFps + (1f - _expSmoothingFactor) * 1f / Time.unscaledDeltaTime;

            if (_timeSinceUpdate < _refreshFrequency)
            {
                _timeSinceUpdate += Time.deltaTime;
                return;
            }

            int fps = Mathf.RoundToInt(_averageFps);

            _textMesh.text = $"FPS "+ fps.ToString();
            _timeSinceUpdate = 0f;
        }

        private static void CopyValueCounter()
        {
            _textMesh = UnityEngine.Object.Instantiate(HUDManager.Instance.weightCounter, HUDManager.Instance.weightCounter.transform, false);
            _textMesh.enabled = !Config.General.disableFPS.Value;
            FPSCounterBase.mls.LogInfo(!Config.General.disableFPS.Value);
            _textMesh.transform.Translate(new Vector3(-0.3f, 0.63f));
        }
    }
}
