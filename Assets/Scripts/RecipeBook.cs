using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipeBook : MonoBehaviour
{
    List<TMP_Text> recipeSlots;
    FoodPreparationScript manager;

    
    private void Start()
    {
        recipeSlots = new List<TMP_Text>();
        for (int i = 0; i < transform.childCount; i++)
        {
            recipeSlots.Add(transform.GetChild(i).GetComponent<TMP_Text>());
        }
        manager = FindObjectOfType<FoodPreparationScript>();

        PopulateList();
    }

    void PopulateList()
    {
        //For each recipe slot in the scene
        for (int i = 0; i < recipeSlots.Count; i++)
        {
            //For when the slot number does not exceed the number of recipes.(If there are more recipes, then we may have a problem!)
            if (manager.recipes.Count > i)
            {
                Recipe currentRecipe = manager.recipes[i];
                string recipeText = null;
                recipeText += "Recipe " + (i+1) + ": ";
                for (int j = 0; j < currentRecipe.ingredients.Count; j++)
                {
                    recipeText += currentRecipe.ingredients[j] + " ";
                    //Adds a + if there are more ingredients to add
                    if (j+1 < currentRecipe.ingredients.Count) { recipeText += "+ "; }
                }
                recipeText += "Using Prep Method " + currentRecipe.prepMethod + " = " + currentRecipe.dishName;

                //Names the recipe slot using the created string
                recipeSlots[i].text = recipeText;
            }
            else { recipeSlots[i].gameObject.SetActive(false); }
        }
    }
}
