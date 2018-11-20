using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewTimerClick : MonoBehaviour, IInputClickHandler {

    public GameObject timer = null;

    public void OnInputClicked(InputClickedEventData eventData) {
        Instantiate(timer, new Vector3(0, 0, -10), Quaternion.identity)
            .transform.Rotate(-90, 0, 0); ;
    }
    
	// Update is called once per frame
	void Update () {
    }

    public void CreateNewTimer() {
        Instantiate(timer, new Vector3(0, 0, -10), Quaternion.identity)
            .transform.Rotate(-90, 0, 0); ;
        Destroy(gameObject.transform.root.gameObject);
    }
}
