using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeController : HandDraggable, IInputClickHandler
{
    public Recipe Recipe { get; set; }
    public SBSCanvas RecipeInstructionPrefab;

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
	}
	
	// Update is called once per frame
	void Update () {
		
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

    private Transform GetChildComponent(string name)
    {
        foreach(Transform child in transform)
        {
            if(child.name == name)
            {
                return child;
            }
        }

        return null;
    }
}
