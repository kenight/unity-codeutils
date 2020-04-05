using UnityEngine;

namespace CodeUtils
{
    // this approach from catlike.com
    public class FpsCounter : MonoBehaviour
    {
        public int averageFps;
        [Range(1, 60)] public int bufferSize = 20;
        public bool drawOnGUI;
        [Range(10, 60)] public int fontSize = 40;

        int[] buffer;
        int index;

        void Start()
        {
            PrepareBuffer();
        }

        void Update()
        {
            CalculateFps();
        }

        void OnGUI()
        {
            if (drawOnGUI) DrawOnGUI();
        }

        void PrepareBuffer()
        {
            bufferSize = Mathf.Clamp(bufferSize, 1, 60);
            buffer = new int[bufferSize];
        }

        void CalculateFps()
        {
            buffer[index++] = (int)(1f / Time.unscaledDeltaTime);
            if (index >= bufferSize)
                index = 0;

            int sum = 0;
            foreach (var b in buffer)
            {
                sum += b;
            }
            averageFps = sum / bufferSize;
        }

        void DrawOnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.fontSize = fontSize;
            style.padding = new RectOffset(10, 0, 10, 0);
            GUILayout.Label(averageFps.ToString(), style);
        }
    }
}