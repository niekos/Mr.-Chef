using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenu : MonoBehaviour {
    public GameObject RecipePrefab;
    public GameObject GuidancePrefab;
    public Guidance Guide { get; set; }
    public Sprite GuidanceImage;

	// Use this for initialization
	void Start () {
        //Test code
        List<string> tostiInstructions = new List<string> { "Check ingredients", "Turn on the sandwich iron", "Scrape the cheese", "Put cheese and ham on the bread",
        "Wait 6 minutes(say set timer)", "Place the bread in the sandwich iron", "Serve with sauce(optional)"};
        List<string> boerenkoolInstructions = new List<string> { "Doe eerst de aardappelen in de pan, daarna de boerenkool en de worst", "Kook tot de aardappelen gaar zijn", "Prak die shit", "Serveer met sju" };

        List<Recipe> recipes = new List<Recipe>();
        recipes.Add(new Recipe("Tosti", Resources.Load<Sprite>("Images/Recipes/Tosti"), "Een tosti is een lekker broodje met kaas en ham.", tostiInstructions));
        recipes.Add(new Recipe("Boerenkool", Resources.Load<Sprite>("Images/Recipes/boerenkool"), "Donders gerecht met rookworst", boerenkoolInstructions));

        LoadRecipes(recipes);
        //End test code

        Guide = Instantiate(GuidancePrefab).GetComponent<Guidance>();
        Guide.transform.parent = Camera.main.transform;
        Guide.SetSprite(GuidanceImage);
        Guide.SetInstruction("Point the cursor onto a recipe and pinch to select");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void LoadRecipes(List<Recipe> recipes)
    {
        int index = 0;
        foreach(var recipe in recipes)
        {
            //var recipePosition = new Vector3(-3.85f,  0.3f, 1.85f);
            var differenceVector = new Vector3(0.004672897f - 3.85f, 100f - 0.3f, -1.503792f - 1.85f);
            var recipePosition = new Vector3(0,0,0);

            var recipeInstance = Instantiate(RecipePrefab);
            recipeInstance.transform.parent = transform;

            var recipeRectTrans = recipeInstance.GetComponent<RectTransform>();
            recipeRectTrans.offsetMin = new Vector2(-30 + (26 * index), 10);
            recipeRectTrans.offsetMax = new Vector2(-30 + (26 * index), 10);

            var localPos = recipeInstance.transform.localPosition;
            recipeInstance.transform.localPosition = new Vector3(localPos.x, localPos.y, 0);
            //recipeInstance.transform.localPosition = new Vector3(-3.85f + ((recipeInstance.transform.localScale.x + 1.5f) * index), 4.0f, 1.85f);
            //recipeInstance.transform.localScale = new Vector3(2,2,2);
            //recipeInstance.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.zero);
            //recipeInstance.transform.position = RecipePrefab.transform.position;
            //recipeInstance.transform.localScale = RecipePrefab.transform.localScale;
            //recipeInstance.transform.localRotation = RecipePrefab.transform.localRotation;
            //recipeInstance.transform.position = recipePosition;

            var recipeController = recipeInstance.GetComponent<RecipeController>();
            recipeController.SetTitle(recipe.Title);
            recipeController.SetDescription(recipe.Description);
            recipeController.SetImage(recipe.Sprite);
            recipeController.Recipe = recipe;
            
            //recipeInstance.SetActive(true);

            index++;
        }

        
    }
}

public class Recipe {
    public string Title { get; set; }
    public Sprite Sprite { get; set; }
    public string Description { get; set; }
    public List<string> Steps { get; set; }

    public Recipe(string title, Sprite sprite, string description, List<string> steps)
    {
        Title = title;
        Sprite = sprite;
        Description = description;
        Steps = steps;
    }
}