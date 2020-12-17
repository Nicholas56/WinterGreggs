using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    TMP_Text scoreTxt;
    int scoreNum;

    int storeNum;
    int currentHighScore;


    private void Awake()
    {
        scoreTxt = GetComponent<TMP_Text>();
        scoreTxt.text = "Score: " + scoreNum;

        storeNum = SceneManager.GetActiveScene().buildIndex; //Get current store number using scene BuildIndex
    }

    public void IncreaseScore(string buttonText)
    {
        int currentHighScore = PlayerPrefs.GetInt("StoreHighScore" + storeNum, scoreNum);
        int scoreAdd = FindCost(buttonText);

        scoreNum +=scoreAdd;
        scoreTxt.text = "Score: £" + scoreNum;

        if(scoreNum > currentHighScore) //Check if current score is higher than the HighScore, 
        {
            PlayerPrefs.SetInt("StoreHighScore" + storeNum, scoreNum);
            print("NewHighScore");
        }

    }

    int FindCost(string textToRead)
    {
        string[] textParts = textToRead.Split(' ');
        string dishName = null;
        for (int i = 1; i < textParts.Length; i++)
        {
            dishName += textParts[i];
            //For all but the last part, adds back in the space
            if (i < textParts.Length-1) { dishName += ' '; }
        }

        List<Recipe> recipeToCheck = FindObjectOfType<FoodPreparationScript>().recipes;
        for (int i = 0; i < recipeToCheck.Count; i++)
        {
            if (recipeToCheck[i].dishName == dishName.Trim('\n'))
            {
                return recipeToCheck[i].dishCost;
            }
        }

        return 0;
    }
}
