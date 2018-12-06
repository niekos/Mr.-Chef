using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenTimerDetail : HandDraggable, IInputClickHandler {

    public GameObject timerDetailScreen = null;

    public void OnInputClicked(InputClickedEventData eventData) {
        CreateNewTimerDetailPanel();
    }

    public override void OnFocusEnter() {
        base.OnFocusEnter();
        
    }

    public void CreateNewTimerDetailPanel() {
        Vector3 pos = gameObject.transform.position;
        GameObject timerDetailScreenClone = Instantiate(timerDetailScreen, new Vector3(pos.x, pos.y, pos.z - 1), Quaternion.identity);
        timerDetailScreenClone.transform.Rotate(-90, 0, 0);
    }
}
