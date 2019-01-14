using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Timer;
using HoloToolkit.Unity.Buttons;

public class NewTimerClick : MonoBehaviour, IInputClickHandler {
    
    public GameObject timer = null;
    private TextMesh timerText;

    public int hours = 0;
    public int minutes = 0;
    public int seconds = 0;

    public void Start() { 
        foreach(Transform child in transform)
        {
            if(child.name == "TimeCanvas")
            {
                timerText = child.GetComponent<TextMesh>();
            }
        }
    }
    
    public void increaseHour(int hoursToAdd) {
        String debugFormat = string.Format("{0} hour(s) added", hoursToAdd);
        Debug.Log(debugFormat);

        if ((hours + hoursToAdd) <= 60) {
            hours += hoursToAdd;
        } else {
            Debug.Log("Max hours reached");
        }
        
        RefreshTimerText();
    }

    public void increaseMinutes(int minutesToAdd) {
        String debugFormat = string.Format("{0} minute(s) added", minutesToAdd);
        Debug.Log(debugFormat);

        int totalNewMinutes = minutes + minutesToAdd;
        if(totalNewMinutes > 60) {
            increaseHour(1);
            totalNewMinutes -= 60;
        }

        minutes = totalNewMinutes;

        RefreshTimerText();
    }

    public void increaseSeconds(int secondsToAdd) {
        String debugFormat = string.Format("{0} second(s) added", secondsToAdd);
        Debug.Log(debugFormat);
        
        int totalNewSeconds = seconds + secondsToAdd;
        if (totalNewSeconds > 60) {
            increaseMinutes(1);
            totalNewSeconds -= 60;
        }

        seconds = totalNewSeconds;

        RefreshTimerText();
    }

    private void RefreshTimerText() {
        string format = "";
        if (hours == 0) {
            format = string.Format("{0}:{1}", minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
        } else {
            format = string.Format("{0}:{1}:{2}", hours.ToString().PadLeft(2, '0'), minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
        }

        timerText.text = format;
    }

    public void OnInputClicked(InputClickedEventData eventData) {

    }

    public void CreateNewTimer() {
        GameObject.Find("OnBoardProcess").GetComponent<OnBoardProcess>().TimerOpen = false;

        GameObject timerClone = Instantiate(timer, new Vector3(0, 0, -10), Quaternion.identity);
        timerClone.transform.Rotate(-90, 0, 0);
        timerClone.GetComponent<Counter>().setTimer(hours, minutes, seconds);
        timerClone.GetComponent<Counter>().StartTimer();

        Destroy(gameObject.transform.root.gameObject);
    }

    public void CancelTimerCreation() {
        GameObject.Find("OnBoardProcess").GetComponent<OnBoardProcess>().TimerOpen = false;

        Destroy(gameObject.transform.root.gameObject);
    }
}
