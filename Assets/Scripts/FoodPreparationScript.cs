using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodPreparationScript : MonoBehaviour
{
    [Tooltip("The list of dishes that can be made in this store")]
    public List<Recipe> recipes = new List<Recipe>();

    List<GameObject> prepIngredients;
    List<GameObject> ovens;

    private void Awake()
    {
        Transform prepTable = GameObject.Find("PrepIngredients").transform;
        Transform ovenHolder = GameObject.Find("OvenPanel").transform;

        prepIngredients = new List<GameObject>();
        ovens = new List<GameObject>();
        //Adds the ingredient object images to a list for easy access. Removes visibility for new game
        for (int i = 0; i < prepTable.childCount; i++)
        {
            prepIngredients.Add(prepTable.GetChild(i).gameObject);
            prepIngredients[i].SetActive(false);
        }
        for (int j = 0; j < ovenHolder.childCount; j++)
        {
            ovens.Add(ovenHolder.GetChild(j).gameObject);//This needs work!!!
            ovens[j].SetActive(false);
        }
    }

    

    /// <summary>
    /// This checks the current ingredients and the recipes. If they match, the dish is made and placed on the table.
    /// </summary>
    /// <param name="prepMethod"></param>
    public void PrepareDish(int prepMethod)
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            if (recipes[i].prepMethod == prepMethod)
            {
                for (int k = 0; k < prepIngredients.Count; k++)
                {
                    if (prepIngredients[k].activeSelf) {
                        if (recipes[i].ingredients.Contains(CheckIngredients()[k]))
                        {
                            List<string> recipe = new List<string>();
                            recipe = recipes[i].ReturnIngredients();
                            List<string> ingreds = CheckIngredients();
                            if (CompareLists(ingreds, recipe))
                            {
                                for (int j = 0; j < prepIngredients.Count; j++)
                                {
                                    if (ingreds.Count > j)
                                    { prepIngredients[j].GetComponentInChildren<TMP_Text>().text = ingreds[j]; }
                                    else { prepIngredients[j].SetActive(false); }
                                }
                                prepIngredients[ingreds.Count + 1].SetActive(true);
                                prepIngredients[ingreds.Count + 1].GetComponentInChildren<TMP_Text>().text = recipes[i].dishName;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Hides the ingredient from the central panel
    /// </summary>
    /// <param name="ingredient"></param>
    public void RemoveIngredient(GameObject ingredient)
    {
        foreach (var item in recipes)
        {
            if (ingredient.GetComponentInChildren<TMP_Text>().text == item.dishName)
            {
                PutInOven(ingredient);
            }
        }
        ingredient.SetActive(false);
    }

    /// <summary>
    /// Adds an ingredient from the left panel to the central panel
    /// </summary>
    /// <param name="ingredient"></param>
    public void PickIngredient(GameObject ingredient)
    {
        for (int i = 0; i < prepIngredients.Count; i++)
        {
            if (!prepIngredients[i].activeSelf)
            {
                prepIngredients[i].SetActive(true);
                ChangeButtonText(prepIngredients[i], ingredient.GetComponentInChildren<TMP_Text>().text);

                return;
            }
        }
    }

    /// <summary>
    /// Sets one of the unused ovens to cook the given dish.
    /// </summary>
    /// <param name="dish"></param>
    void PutInOven(GameObject dish)
    {
        for (int i = 0; i < ovens.Count; i++)
        {
            if (!ovens[i].activeSelf)
            {
                ovens[i].SetActive(true);
                ChangeButtonText(ovens[i], "Cooking: " + dish.GetComponentInChildren<TMP_Text>().text);

                return;
            }
        }
    }

    /// <summary>
    /// Returns a list of all the currently active ingredients on the table
    /// </summary>
    /// <returns></returns>
    List<string> CheckIngredients()
    {
        List<string> currentIngredients = new List<string>();

        for (int i = 0; i < prepIngredients.Count; i++)
        {
            if (prepIngredients[i].activeSelf)
            {
                currentIngredients.Add(prepIngredients[i].GetComponentInChildren<TMP_Text>().text);
            }
        }
        if (currentIngredients.Count > 0)
            return currentIngredients;
        else return null;
    }

    /// <summary>
    /// Changes the text on button objects to the new text given.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="newText"></param>
    void ChangeButtonText(GameObject button,string newText)
    {
        button.GetComponentInChildren<TMP_Text>().text = newText;
    }

    /// <summary>
    /// Checks that every item in the second list is contained in the first list and returns boolean
    /// </summary>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns></returns>
    bool CompareLists(List<string> list1, List<string> list2)
    {
        List<string> itemsToRmove = new List<string>();
        foreach (string item in list2)
        {
            if (list1.Contains(item))
            {
                list1.Remove(item);
                itemsToRmove.Add(item);
            }
        }
        for (int i = 0; i < itemsToRmove.Count; i++)
        {
            list2.Remove(itemsToRmove[i]);
        }
        if (list2.Count == 0) { return true; }
        else { return false; }
    }
}
