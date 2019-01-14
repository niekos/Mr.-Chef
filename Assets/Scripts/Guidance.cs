using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guidance : MonoBehaviour {

    private Vector3 _outsidePositionMargin = new Vector3(0, -3, 0);
    private Vector3 _startPositionMargin = new Vector3(0, 1.5f, 0);
    private Vector3 _leftCornerMargin = new Vector3(0, 0, 100);
    private const float SPEED = 2.0f;
    private const float DURATION = 1.0f;
    private MoveObject _moveControl;
    private bool _onScreen = false;

    // Use this for initialization
    void Awake () {
        // Animation control
        _moveControl = GetComponent<MoveObject>();
        _moveControl.SetOptions(SPEED, DURATION);

        // Register destroy func to dispose the guidance object when it is outside of the screen
        _moveControl.OnAnimateFinished += TimeToDestroy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSprite(Sprite guideSprite)
    {
        foreach (Transform child in transform.GetChild(0).transform)
        {
            if (child.name == "GuidanceImage")
            {
                var image = child.GetComponent<Image>();
                image.sprite = guideSprite;
                image.gameObject.SetActive(true);
            }
        }
    }

    public void SetInstruction(string instruction)
    {
        // Set instruction text
        GetComponentInChildren<Text>().text = instruction;

        ShowGuide();
    }

    private void ShowGuide()
    {
        // Set guide position to the left corner of the camera view
        var camPos = Camera.main.transform.position;
        transform.localPosition = new Vector3(2f, -4.8f, 30);

        Vector3 startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + _startPositionMargin.y, transform.localPosition.z);
        _moveControl.MoveTo(startPosition);
    }

    public void CloseInstruction()
    {
        Vector3 outsidePosition = new Vector3(transform.localPosition.x, transform.localPosition.y + _outsidePositionMargin.y, transform.localPosition.z);
        _moveControl.MoveTo(outsidePosition);
    }

    private void TimeToDestroy()
    {
        _onScreen = !_onScreen;

        // Dispose the guide
        if (!_onScreen)
        {
            Destroy(gameObject);
        }
    }
}