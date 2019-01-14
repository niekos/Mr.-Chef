using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenuPanel : MonoBehaviour {

    private OnBoardProcess _onboardProcess;

	// Use this for initialization
	void Start () {
        _onboardProcess = GameObject.Find("OnBoardProcess").GetComponent<OnBoardProcess>();

        // Register buttons
        transform.GetChild(0).GetComponent<ControlMenuButton>().OnClick += HarmburgerClicked;
        transform.GetChild(1).GetComponent<ControlMenuButton>().OnClick += MicrophoneClicked;
        transform.GetChild(2).GetComponent<ControlMenuButton>().OnClick += TimerClicked;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HarmburgerClicked()
    {
        _onboardProcess.MenuHandler();
    }

    private void MicrophoneClicked()
    {
        _onboardProcess.VoiceOn = !_onboardProcess.VoiceOn;
    }

    private void TimerClicked()
    {
        _onboardProcess.TimerHandler();
    }
}
