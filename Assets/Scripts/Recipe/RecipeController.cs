using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : HandDraggable, IInputClickHandler
{
    public Recipe Recipe { get; set; }
    public RecipeInstruction RecipeInstructionPrefab;
    public OnBoardProcess OnboardProcess;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var recipeInstruction = Instantiate(RecipeInstructionPrefab);
        recipeInstruction.UpdateInstructions(Recipe.Steps);
        recipeInstruction.gameObject.SetActive(true);

        // Close menu
        var onboardProcess = Instantiate(OnboardProcess);
        onboardProcess.MenuOpen = false;
        onboardProcess.DestroyObjectsInLayer(10);
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnFocusEnter()
    {
        base.OnFocusEnter();
        
        GetChildComponent("RecipeBackground").GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Recipe/RecipeSelectedBackground");
    }

    public override void OnFocusExit()
    {
        base.OnFocusExit();

        GetChildComponent("RecipeBackground").GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Recipe/RecipeBackground");
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
