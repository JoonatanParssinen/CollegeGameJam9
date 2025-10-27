using UnityEngine;
using UnityEngine.UI;

public class GlitchBar : MonoBehaviour
{
    public Slider slider;
    public float tickInterval = 4f; //seconds per tick
    public float smoothSpeed = 2f;    // how fast the smoothing is

    private float timer = 0f; 
    private float targetValue = 0f;   // target value to reach

    void Start()
    {
            targetValue = slider.value; 
    }

    void Update()
    {
        if (slider == null) return;

        // Count time until the next tick
        timer += Time.deltaTime;

        if (timer >= tickInterval)
        {
            timer = 0f;

            if (targetValue < slider.maxValue)
                targetValue += 1;  // increase target value
        }

        // Smoothly move towards target value
        slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * smoothSpeed); 
    }
}