using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeController : HandDraggable, IInputClickHandler
{
    private Vector3 _outsidePosition;
    private Vector3 _startPosition;
    private Vector3 _upMargin = new Vector3(0, 28, 0);
    private Vector3 _downMargin = new Vector3(0, -28, 0);
    private MoveObject _moveControl;

    public float Speed { get; set; }
    public float Duration { get; set; }

    public Recipe Recipe { get; set; }
    public SBSCanvas RecipeInstructionPrefab;

    public bool Animating { get; set; }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var recipeInstruction = Instantiate(RecipeInstructionPrefab);
        recipeInstruction.UpdateInstructions(Recipe.Steps);
        recipeInstruction.gameObject.SetActive(true);

        // Close menu
        var OnBoardProcess = GameObject.Find("OnBoardProcess").GetComponent<OnBoardProcess>();
        OnBoardProcess.DestroyAllGuidance();
        OnBoardProcess.MenuOpen = false;
        OnBoardProcess.DestroyObjectsInLayer(10);

        // Set cooking state true
        OnBoardProcess.Cooking = true;
    }

    // Use this for initialization
    void Start () {
        // Default settings
        Speed = 5f;
        Duration = 0.5f;
        Animating = false;

        _moveControl = GetComponent<MoveObject>();
        _moveControl.SetOptions(Speed, Duration);

        var currentPos = transform.localPosition;
        _outsidePosition = new Vector3(currentPos.x, 50, currentPos.z);
        _startPosition = new Vector3(currentPos.x, 13, currentPos.z);

        _moveControl.OnAnimateFinished += AnimationDone;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AnimateDown(bool startPosition, float delay)
    {
        if(startPosition)
        {
            _moveControl.MoveTo(_startPosition, delay);
            Animating = true;
        }
        else
        {
            AnimateMove(_downMargin, delay);
        }
    }

    public void AnimateUp(bool outside, float delay)
    {
        if(outside)
        {
            _moveControl.MoveTo(_outsidePosition, delay);
            Animating = true;
        }
        else
        {
            AnimateMove(_upMargin, delay);
        }
    }

    private void AnimateMove(Vector3 margin, float delay)
    {
        var currentPos = transform.localPosition;
        Vector3 outsidePos = new Vector3(currentPos.x, currentPos.y + margin.y, currentPos.z);
        _moveControl.MoveTo(outsidePos, delay);
        Animating = true;
    }

    private void AnimationDone()
    {
        Animating = false;
    }

    public void SetTitle(string title)
    {
        transform.GetChild(0).GetComponentInChildren<Text>().text = title;
    }

    public void SetDescription(string description)
    {
        transform.GetChild(1).GetComponentInChildren<Text>().text = description;
    }

    public void SetImage(Sprite image)
    {
        GetComponent<Image>().sprite = image;
    }

    public override void OnFocusEnter()
    {
        base.OnFocusEnter();

        transform.GetChild(0).GetComponent<Image>().color = new Color32(170, 213, 255, 245);
    }

    public override void OnFocusExit()
    {
        base.OnFocusExit();

        transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 245);
    }
}
