using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    TMP_Text scoreTxt;
    int scoreNum;

    private void Awake()
    {
        scoreTxt = GetComponent<TMP_Text>();
        scoreTxt.text = "Score: " + scoreNum;
    }

    public void IncreaseScore(string buttonText)
    {
        int scoreAdd = FindCost(buttonText);

        scoreNum +=scoreAdd;
        scoreTxt.text = "Score: " + scoreNum;     
    }

    int FindCost(string textToRead)
    {
        string[] textParts = textToRead.Split(' ');
        string dishName = null;
        for (int i = 1; i < textParts.Length; i++)
        {
            dishName += textParts[i];
        }

        List<Recipe> recipeToCheck = FindObjectOfType<FoodPreparationScript>().recipes;
        for (int i = 0; i < recipeToCheck.Count; i++)
        {
            if (recipeToCheck[i].dishName == dishName)
            {
                return recipeToCheck[i].dishCost;
            }
        }

        return 0;
    }
}
