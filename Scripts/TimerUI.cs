using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimerUI : MonoBehaviour
{

    public TextMeshProUGUI text;

    int minutes;
    int seconds;
    float miliseconds;
    bool timerStopped;

    
    private void Start()
    {
        // Set the default values of the timer
        text = GetComponent<TextMeshProUGUI>();
        minutes = 59;
        seconds = 59;
        miliseconds = 0;
        timerStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the timer has not been told to stop...
        if (!timerStopped)
        {
            // Do timer countdown
            miliseconds = miliseconds + Time.deltaTime;
            if (miliseconds > 1)
            {
                miliseconds = 0;
                seconds--;
                if (seconds < 0)
                {
                    seconds = 59;
                    minutes--;

                    // If the time finishes (minutes < 0),
                    // Set the minutes and seconds to 0 and stop the timer,
                    // and trigger the good ending.
                    if (minutes < 0)
                    {
                        minutes = 0;
                        seconds = 0;
                        timerStopped = true;
                        FindObjectOfType<GameManager>().EndGameGood();
                    }
                }
            }
        }

        // Print the timer as text
        string minutesText;
        string secondsText;

        if (minutes < 10)
            minutesText = "0" + minutes;
        else
            minutesText = "" + minutes;

        if (seconds < 10)
            secondsText = "0" + seconds;
        else
            secondsText = "" + seconds;

        text.text = minutesText + ":" + secondsText;
    }

    // Sets the minutes and seconds of the timer.
    public void SetMinSec(int min, int sec)
    {
        minutes = min;
        seconds = sec;
    }

}
