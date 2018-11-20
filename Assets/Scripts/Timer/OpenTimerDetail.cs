using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenTimerDetail : HandDraggable, IInputClickHandler {

    public GameObject timerDetailScreen = null;

    public void OnInputClicked(InputClickedEventData eventData) {
        Instantiate(timerDetailScreen, new Vector3(0, 0, 10), Quaternion.identity);
    }

    public override void OnFocusEnter() {
        base.OnFocusEnter();

        Instantiate(timerDetailScreen, new Vector3(0, 0, 10), Quaternion.identity)
            .transform.Rotate(-90,0,0);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
