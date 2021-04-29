using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {

        if (time > 0)
        {
            time -= Time.deltaTime;
            DisplayTime(time);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 20)
        {
            timerText.color = Color.red;
        }

        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
