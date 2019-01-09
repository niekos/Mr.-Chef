using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenu : MonoBehaviour {
    public GameObject RecipePrefab;

	// Use this for initialization
	void Start () {
        //Test code
        List<string> tostiInstructions = new List<string> { "Check ingredients", "Turn on the sandwich iron", "Scrape the cheese", "Put cheese and ham on the bread",
        "Wait 6 minutes(say set timer)", "Place the bread in the sandwich iron", "Serve with sauce(optional)"};
        List<string> boerenkoolInstructions = new List<string> { "Doe eerst de aardappelen in de pan, daarna de boerenkool en de worst", "Kook tot de aardappelen gaar zijn", "Prak die shit", "Serveer met sju" };

        List<Recipe> recipes = new List<Recipe>();
        recipes.Add(new Recipe("Tosti", Resources.Load<Texture2D>("Images/Recipes/Tosti"), "Een tosti is een lekker broodje met kaas en ham.", tostiInstructions));
        recipes.Add(new Recipe("Boerenkool", Resources.Load<Texture2D>("Images/Recipes/boerenkool"), "Donders gerecht met rookworst", boerenkoolInstructions));

        LoadRecipes(recipes);
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
            recipeInstance.transform.localPosition = new Vector3(-3.85f + ((recipeInstance.transform.localScale.x + 1.5f) * index), 4.0f, 1.85f);
            recipeInstance.transform.localScale = new Vector3(2,2,2);
            recipeInstance.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.zero);
            //recipeInstance.transform.position = RecipePrefab.transform.position;
            //recipeInstance.transform.localScale = RecipePrefab.transform.localScale;
            //recipeInstance.transform.localRotation = RecipePrefab.transform.localRotation;
            var thistransform = transform;
            //recipeInstance.transform.position = recipePosition;
            recipeInstance.GetComponentInChildren<TextMesh>().text = recipe.Title;

            foreach(Transform child in recipeInstance.transform)
            {
                if(child.transform.name == "RecipePhoto")
                {
                    child.GetComponent<Renderer>().material.mainTexture = recipe.Texture;
                }
            }
            
            recipeInstance.GetComponent<RecipeController>().Recipe = recipe;
            recipeInstance.SetActive(true);

            index++;
        }

        
    }
}

public class Recipe {
    public string Title { get; set; }
    public Texture Texture { get; set; }
    public string Description { get; set; }
    public List<string> Steps { get; set; }

    public Recipe(string title, Texture texture, string description, List<string> steps)
    {
        Title = title;
        Texture = texture;
        Description = description;
        Steps = steps;
    }
}