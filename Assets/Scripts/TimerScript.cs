using TMPro;
using UnityEngine;


public class TimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool timerIsRunning = false;

    public TMP_Text TimerText;


    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeLeft >= 1f)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeLeft = 0;
                timerIsRunning = false;
            }
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime -= 1;

        float minutes = Mathf.RoundToInt(currentTime / 60);
        float seconds = Mathf.RoundToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}