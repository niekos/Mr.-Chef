using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : HandDraggable, IInputClickHandler
{
    public Recipe Recipe { get; set; }
    public RecipeInstruction RecipeInstruction { get; set; }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var recipeInstructionView = GameObject.Find("RecipeInstruction");
        //var recipeInstructionController = recipeInstructionView.GetComponent<RecipeInstruction>();
        //recipeInstructionController.UpdateInstructions(Recipe.Steps);
        recipeInstructionView.SetActive(true);

        Destroy(transform.parent.parent.gameObject);
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
