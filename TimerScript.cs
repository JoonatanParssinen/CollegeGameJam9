using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // N‰ytt‰‰ muodossa mm:ss (esim. 0:07 tai 1:23)
        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
