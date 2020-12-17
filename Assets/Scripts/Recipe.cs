using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    [Tooltip("Name of the dish made using this recipe")]
    public string dishName;
    [Tooltip("Which method is used to make this dish")]
    public int prepMethod;
    [Tooltip("The list of ingredients in this recipe")]
    public List<string> ingredients = new List<string>();
    [Tooltip("The imageof rthe dish being made")]
    public Sprite dishSprite;
    [Tooltip("The amount to add to the score when delivered")]
    public int dishCost;

    public List<string> ReturnIngredients()
    {
        List<string> listIngreds = new List<string>(ingredients.Count);
        for (int i = 0; i < ingredients.Count; i++)
        {
            listIngreds.Add(ingredients[i]);
        }

        return listIngreds;
    }
}
