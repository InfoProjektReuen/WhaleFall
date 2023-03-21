using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public float deltaTime = 0.0f;
    public TextMeshProUGUI fpsText;
    private float updateInterval = 0.5f;
    private float lastUpdateTime = 0.0f;

    void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (Time.time - lastUpdateTime > updateInterval)
        {
            float fps = 1.0f / deltaTime;
            fpsText.text = string.Format("{0:0.} FPS", fps);
            lastUpdateTime = Time.time;
        }
    }
}