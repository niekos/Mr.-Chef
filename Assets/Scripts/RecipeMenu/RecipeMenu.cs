using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenu : MonoBehaviour {
    public GameObject RecipePrefab;
    public GameObject GuidancePrefab;
    public Guidance Guide { get; set; }
    public Sprite GuidanceImage;

    private List<Recipe> Recipes { get; set; }
    
    private int _currentY = 0;

	// Use this for initialization
	void Start () {
        //Test code
        List<string> recipe1 = new List<string> { "Get 2 slices of bread", "Scrape the cheese", "Put the cheese and ham on 1 slice of bread", "Put the second slice of bread on the first one",
        "Put the sandwich in the grill and wait 6 minutes" };
        List<string> recipe2 = new List<string> { "Preheat the oven to 175 degrees", "Cook the potatoes for 20 minutes in boiling water", "Mash the potatoes", "Cook the sausage and the sprouts",
        "Put the sausage, mashed potatoes and sprouts in the oven for 20 minutes", "Take everything out of the oven after the 20 minutes"};
        List<string> recipe3 = new List<string> { "Preheat the oven to 200 degrees", "Sift the flour and baking powder into a medium bowl and set aside", "Beat butter and sugar with an electric mixer until light and fluffy",
        "Add room-temperature eggs one at a time", "Pour in the flour mixture alternately with the milk, mixing until just incorporated", "Bake in the preheated oven for 20 minutes", "Cool the cake in the pan for 10 minutes" };
        List<string> recipe4 = new List<string> { "Preheat the oven to 200 degrees", "Place three sprigs of lavender on top of each chicken breast half", "Wrap two slices of bacon around each piece of chicken keeping the lavender inside",
        "Place chicken into a shallow baking dish", "Season with salt, pepper, and red pepper flakes", "Bake the chicken for 20 minutes, turning once", "Turn again so the lavender is on top, and sprinkle with shredded cheese",
        "Continue baking 10 minutes, or until cheese has melted and chicken juices run clear" };
        List<string> recipe5 = new List<string> { "In a skillet over medium heat, combine red wine, onion, garlic, and thyme", "Bring to a boil, and cook until volume is reduced by about 1/4", "Melt butter in a skillet over medium heat until just beginning to brown",
        "Add beef, and cook until evenly brown", "Remove beef, and stir into cooled wine mixture", "Sprinkle flour into skillet. Reduce heat, and cook slowly until flour is browned", "Gradually stir in beef stock, and stir until mixture comes to a boil",
        "Season with salt and pepper, and simmer uncovered for about 10 minutes", "Stir in beef and wine mixture. Cover, and cook very gently for 40 to 45 minutes", "Lay mushrooms on top of beef. Cover, and simmer for about 10 more minutes",
        "Transfer beef and mushrooms to a serving dish. Taste sauce and adjust seasonings", "Simmer until sauce has reduced to desired consistency, then pour over meat"};
        List<string> recipe6 = new List<string> { "Place a steamer into a saucepan and fill with water just below the bottom of the steamer", "Bring water to a boil", "Add cauliflower; cover the saucepan with a lid and steam cauliflower until tender, 10 to 12 minutes",
        "Melt butter in a large pot over medium heat", "Whisk flour into melted butter; cook, stirring constantly until raw flour taste cooks off and mixture darkens, 3 to 4 minutes", "Gradually whisk milk into butter mixture; cook, stirring constantly, until sauce thickens, about 8 minutes",
        "Remove pot from heat; stir in Cheddar cheese", "Season sauce with salt and white pepper", "Stir steamed cauliflower into cheese sauce; season with salt and white pepper"};
        List<string> recipe7 = new List<string> { "Preheat the oven to 200 degrees", "Lightly grease the bottom of a deep-dish pie plate", "Beat butter, sugar, and egg in a bowl until creamy", "Blend in flour to form a dough, using your hands to knead it together at the end",
        "Roll pastry out on a lightly floured surface and place into the prepared pie plate so it covers the bottom and the sides", "Beat eggs and sugar in a bowl using an electric mixer. Beat in vanilla extract", "Gradually stir in cold milk until fully incorporated",
        "Pour custard mixture over the pastry base and sprinkle with nutmeg", "Bake in the preheated oven for 45 minutes", "Remove from the oven and cool completely before serving, about 1 hour"};
        List<string> recipe8 = new List<string> { "Combine yellow onion, white and light green parts of green onions, soy sauce, sugar, sesame seeds, garlic, sesame oil, red pepper flakes, ginger, and black pepper in a bowl until marinade is well mixed", "Add steak slices to marinade; cover and refrigerate, 1 hour to 1 day",
        "Heat a skillet over medium heat", "Working in batches, cook and stir steak and marinade together in the hot skillet, adding honey to caramelize the steak, until steak is cooked through, about 5 minutes", "Garnish bulgogi with green parts of green onions"};
        List<string> recipe9 = new List<string> { "Heat olive oil in a skillet over medium heat", "Add onion; cook and stir until the onion has softened and turned translucent, about 5 minutes", "Reduce heat to medium-low and continue cooking and stirring until the onion is very tender and dark brown, 15 to 20 minutes more",
        "Stir in the garlic, green chiles, ginger paste, cardamom seeds, cloves, and cinnamon sticks", "Cook and stir until the garlic begins to brown, 3 to 5 more minutes", "Mix cumin, coriander, turmeric, garlic powder, cayenne pepper, and water into the onion mixture",
        "Simmer until most of the water has evaporated and the mixture has thickened", "Stir in beef chuck pieces until coated with spice mixture; simmer over medium-low heat, stirring occasionally, until the beef is cooked through and tender, about 1 to 1 1/2 hours"};

        Recipes = new List<Recipe>();
        Recipes.Add(new Recipe("Grilled cheese sandwich", Resources.Load<Sprite>("Images/Recipes/cheese-sandwich"), "A sandwich with cheese and ham", recipe1));
        Recipes.Add(new Recipe("Banger and Mash", Resources.Load<Sprite>("Images/Recipes/Banger-mash"), "Mashed potatoes with sausage and sprouts", recipe2));
        Recipes.Add(new Recipe("Sponge cake", Resources.Load<Sprite>("Images/Recipes/sponge-cake"), "A perfect cake to eat during tea time", recipe3));
        Recipes.Add(new Recipe("Lavender Chicken", Resources.Load<Sprite>("Images/Recipes/lavender-chicken"), "Chicken with lavender, bacon and cheese", recipe4));
        Recipes.Add(new Recipe("Saute of Beef with Wild Mushrooms", Resources.Load<Sprite>("Images/Recipes/saute-beef"), "An excellent main meal packed full of taste", recipe5));
        Recipes.Add(new Recipe("Cauliflower cheese", Resources.Load<Sprite>("Images/Recipes/cauliflower-cheese"), "A classic heartwarming English dish", recipe6));
        Recipes.Add(new Recipe("Homemade baked egg custard", Resources.Load<Sprite>("Images/Recipes/egg-custard"), "Easy to make", recipe7));
        Recipes.Add(new Recipe("Easy Bulgogi", Resources.Load<Sprite>("Images/Recipes/easy-bulgogi"), "Korean BBQ Beef", recipe8));
        Recipes.Add(new Recipe("Authentic Bangladeshi Beef Curry", Resources.Load<Sprite>("Images/Recipes/beef-curry"), "This spicy beef curry is best served with plain basmati rice or eaten with naan or pita bread", recipe9));

        LoadRecipes(Recipes);
        //End test code

        transform.GetChild(0).GetComponent<ControlMenuButton>().OnClick += BrowseUp;
        transform.GetChild(1).GetComponent<ControlMenuButton>().OnClick += BrowseDown;

        Guide = Instantiate(GuidancePrefab).GetComponent<Guidance>();
        Guide.transform.parent = Camera.main.transform;
        Guide.SetSprite(GuidanceImage);
        Guide.SetInstruction("Point the cursor onto a recipe and pinch to select");
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    BrowseUp();
        //}
        //if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    BrowseDown();
        //}
    }

    private bool IsAnimating()
    {
        foreach(Transform child in transform)
        {
            var controller = child.GetComponent<RecipeController>();
            if(controller != null)
            {
                if(controller.Animating)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void BrowseUp()
    {
        int rows = Mathf.CeilToInt(((float)Recipes.Count) / 3);

        if (_currentY < rows - 1 && !IsAnimating())
        {
            // First row
            var firstRow = GetRecipes(_currentY);
            foreach(var item in firstRow)
            {
                var itemControl = item.GetComponent<RecipeController>();

                itemControl.AnimateUp(true, 0);
            }

            // Other rows
            for (int i = _currentY + 1; i < rows; i++)
            {
                var otherRows = GetRecipes(_currentY);
                foreach (var item in otherRows)
                {
                    var itemControl = item.GetComponent<RecipeController>();

                    itemControl.AnimateUp(false, 0);
                }
            }
            
            _currentY++;
        }
    }

    private void BrowseDown()
    {
        int rows = Mathf.CeilToInt(((float)Recipes.Count) / 3);

        if (_currentY > 0 && !IsAnimating())
        {
            float delay = 0;
            // First row
            var firstRow = GetRecipes(_currentY - 1);
            foreach (var item in firstRow)
            {
                var itemControl = item.GetComponent<RecipeController>();

                itemControl.AnimateDown(true, 0);
                
            }

            /// Other rows
            for (int i = _currentY; i < rows; i++)
            {
                var otherRows = GetRecipes(i);
                foreach (var item in otherRows)
                {
                    var itemControl = item.GetComponent<RecipeController>();

                    itemControl.AnimateDown(false, 0);
                }
            }
            _currentY--;
        }
    }

    private List<Transform> GetRecipes(int row)
    {
        List<Transform> recipes = new List<Transform>();

        var startIndex = (row * 3) + 2;
        for(int i = startIndex; i < transform.childCount; i++)
        {
            recipes.Add(transform.GetChild(i));
        }

        return recipes;
    }

    private void LoadRecipes(List<Recipe> recipes)
    {
        int xIndex = 0;
        int yIndex = 0;
        foreach(var recipe in recipes)
        {
            //var recipePosition = new Vector3(-3.85f,  0.3f, 1.85f);
            var differenceVector = new Vector3(0.004672897f - 3.85f, 100f - 0.3f, -1.503792f - 1.85f);
            var recipePosition = new Vector3(0,0,0);

            var recipeInstance = Instantiate(RecipePrefab);
            recipeInstance.transform.parent = transform;

            //var recipeRectTrans = recipeInstance.GetComponent<RectTransform>();
            //recipeRectTrans.offsetMin = new Vector2(-30 + (26 * xIndex), 10 - (28 * yIndex));
            //recipeRectTrans.offsetMax = new Vector2(-30 + (26 * xIndex), 10 - (28 * yIndex));

            var localPos = recipeInstance.transform.localPosition;
            recipeInstance.transform.localPosition = new Vector3(-30 + (26 * xIndex), 13 - (28 * yIndex), 0);
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

            if(xIndex > 1)
            {
                xIndex = -1;
                yIndex++;
            }
            xIndex++;
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