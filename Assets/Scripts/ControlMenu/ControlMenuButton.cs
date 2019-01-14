using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenuButton : HandDraggable, IInputClickHandler
{
    public delegate void OnClickFunc();
    public event OnClickFunc OnClick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnFocusEnter()
    {
        base.OnFocusEnter();

        //GetComponentInChildren<Image>().color = Color.black;
        transform.GetChild(0).GetComponentInChildren<Image>().color = new Color32(74,187,252, 100);
    }

    public override void OnFocusExit()
    {
        base.OnFocusExit();

        //GetComponentInChildren<Image>().color = Color.white;
        transform.GetChild(0).GetComponentInChildren<Image>().color = Color.black;
    }
    
    public virtual void OnInputClicked(InputClickedEventData eventData)
    {
        if(OnClick != null)
        {
            OnClick();
        }
    }
}
