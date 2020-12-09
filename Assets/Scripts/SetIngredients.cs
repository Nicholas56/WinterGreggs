using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetIngredients : MonoBehaviour
{
    public Transform ingredientsHolder;
    public List<Ingredient> ingredients;

    private void Awake()
    {
        for (int i = 0; i < ingredientsHolder.childCount; i++)
        {
            if (i > ingredients.Count) { return; }

            ingredientsHolder.GetChild(i).GetChild(0).GetComponent<Image>().sprite = ingredients[i].ingredientImage;
            ingredientsHolder.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text = ingredients[i].ingredientName;
        }
    }
}

[System.Serializable]
public class Ingredient
{
    public string ingredientName;
    public Sprite ingredientImage;
}
