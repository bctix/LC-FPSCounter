using System.Collections;
using UnityEngine;

namespace FPSCounter
{
    class FPSCounterGUI : MonoBehaviour
    {
        // old unused stuff, archiving it tho cause i like to keep the history of my mods.
        private GUIStyle style;

        private float count;

        private IEnumerator Start()
        {
            style.normal.textColor = new Color(194, 78, 24);
            //style.font = 
            //GUI.depth = 2;
            while (true)
            {
                count = 1f / Time.unscaledDeltaTime;
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 40, 100, 25), "FPS: " + Mathf.Round(count));
        }
    }
}
