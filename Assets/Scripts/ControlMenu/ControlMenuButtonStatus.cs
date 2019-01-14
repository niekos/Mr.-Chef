using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenuButtonStatus : ControlMenuButton {

    private bool statusEnabled = true;
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    public override void OnInputClicked(InputClickedEventData eventData)
    {
        var used = eventData.used;
        if (!eventData.used)
        {
            if (statusEnabled)
            {
                transform.GetChild(0).GetComponentInChildren<Image>().sprite = disabledSprite;
                statusEnabled = false;
            }
            else
            {
                transform.GetChild(0).GetComponentInChildren<Image>().sprite = enabledSprite;
                statusEnabled = true;
            }
            base.OnInputClicked(eventData);

            eventData.Use();
        }
    }

}
