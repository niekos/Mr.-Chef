using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class SBSPanel : MonoBehaviour {

    public GameObject StepPrefab;
    public int CurrentIndex { get; set; }
    private int CurrentCheckIndex { get; set; }

    private List<GameObject> _steps = new List<GameObject>();
    private Vector3 _outsidePositionMargin = new Vector3(0, 8, 0);
    private Vector3 _startPositionMargin = new Vector3(0, -4, 0);
    private const float STEPHEIGHT = 1.2f;
    private const float STEPSPEED = 1;
    private const float ANIMDURATION = 1.0f;

    public GameObject GuidePrefab;
    public Guidance Guide { get; set; }

	// Use this for initialization
	void Start () {
        Guide = Instantiate(GuidePrefab).GetComponent<Guidance>();
        Guide.transform.parent = Camera.main.transform;
        Guide.SetInstruction("Click on or say next/previous to navigate over the instructions");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public int Check()
    {
        if(Guide != null)
        {
            Guide.CloseInstruction();
        }

        if (CurrentCheckIndex < _steps.Count)
        {
            _steps[CurrentCheckIndex].transform.GetChild(1).gameObject.SetActive(true);
            CurrentCheckIndex++;
        }

        return (int)(((float)CurrentCheckIndex / _steps.Count) * 100.0f);
    }

    public int UndoCheck()
    {
        if (CurrentCheckIndex > 0)
        {
            CurrentCheckIndex--;
            _steps[CurrentCheckIndex].transform.GetChild(1).gameObject.SetActive(false);
        }

        return (int)(((float)CurrentCheckIndex / _steps.Count) * 100.0f);
    }

    private Vector3 GetStartPosition()
    {
        return new Vector3(0, (transform.localPosition.y - _startPositionMargin.y), 0);
    }

    public void SetInstructionList(List<string> instructions)
    {
        var loopIndex = 0;
        foreach (string instruction in instructions)
        {
            GameObject step = Instantiate(StepPrefab, new Vector3(-3.5f, 6.5f - (STEPHEIGHT * loopIndex), 9), Quaternion.identity);

            step.AddComponent<MoveObject>();
            step.GetComponentInChildren<Text>().text = instruction;

            var moveObject = step.GetComponent<MoveObject>();
            moveObject.SetOptions(STEPSPEED, ANIMDURATION);

            // Set parent
            step.transform.parent = transform;

            _steps.Add(step);

            loopIndex++;
        }
    }

    public void Forward()
    {
        if (CurrentIndex < _steps.Count - 1)
        {
            MoveObject moveControl;

            // Object that moves outside of the frame
            var step = _steps[CurrentIndex];
            moveControl = step.GetComponent<MoveObject>();

            // Current outside position
            Vector3 outsidePosition = new Vector3(step.transform.localPosition.x, transform.localPosition.y + _outsidePositionMargin.y, step.transform.localPosition.z);
            moveControl.MoveTo(outsidePosition);

            // Rest of the objects in container
            int loopIndex = 0;
            for (int i = CurrentIndex + 1; i < _steps.Count; i++)
            {
                step = _steps[i];
                moveControl = _steps[i].GetComponent<MoveObject>();

                // The rest of the list goes to the start position
                float yVal = GetStartPosition().y - (STEPHEIGHT * loopIndex);
                Vector3 startPosition = new Vector3(step.transform.localPosition.x, yVal, step.transform.localPosition.z);

                moveControl.MoveTo(startPosition);

                loopIndex++;
            }

            CurrentIndex++;
        }
    }

    public void Backward()
    {
        if (CurrentIndex > 0)
        {
            CurrentIndex--;

            MoveObject moveControl;

            // Object that moves outside of the frame
            var step = _steps[CurrentIndex];
            moveControl = step.GetComponent<MoveObject>();

            // Current start position
            Vector3 outsidePosition = new Vector3(step.transform.localPosition.x, transform.localPosition.y - _startPositionMargin.y, step.transform.localPosition.z);
            moveControl.MoveTo(outsidePosition);

            // Rest of the objects in container
            int loopIndex = 0;
            for (int i = CurrentIndex + 1; i < _steps.Count; i++)
            {
                step = _steps[i];
                moveControl = step.GetComponent<MoveObject>();

                // The rest of the list goes to the start position
                float yVal = (GetStartPosition().y - STEPHEIGHT) - (STEPHEIGHT * loopIndex);
                Vector3 startPosition = new Vector3(step.transform.localPosition.x, yVal, step.transform.localPosition.z);
                moveControl.MoveTo(startPosition);

                loopIndex++;
            }
        }
    }
}
