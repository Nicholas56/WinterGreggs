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
    SoundManager sound;
    List<Ingredient> ingredientInfo;

    private void Awake()
    {
        Transform prepTable = GameObject.Find("PrepIngredients").transform;
        Transform ovenHolder = GameObject.Find("OvenPanel").transform;
        sound = FindObjectOfType<SoundManager>();
        ingredientInfo = FindObjectOfType<SetIngredients>().ingredients;

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
            //This checks each recipe to see if this prep method applies. Runs this code for each recipe.
            if (recipes[i].prepMethod == prepMethod)
            {
                //Makes a list of each of the ingredients on the table
                List<string> currentIngreds = CheckIngredients();
                if (currentIngreds == null) { return; }
                for (int k = 0; k < currentIngreds.Count; k++)
                {
                    //If the button on the table is not active, this cycle does nothing
                    if (prepIngredients[k].activeSelf)
                    {
                        //This checks to see if the recipe includes one of the ingredients on the table, compares them properly later.
                        if (recipes[i].ingredients.Contains(currentIngreds[k]))
                        {
                            List<string> recipe = new List<string>();
                            recipe = recipes[i].ReturnIngredients();
                            List<string> ingreds = currentIngreds;
                            //The comparison of ingredients on the table and the recipe being looked at happens here.
                            if (CompareLists(ingreds, recipe))
                            {
                                for (int j = 0; j < prepIngredients.Count; j++)
                                {
                                    //This checks that the number of buttons match the remaining current ingredients, setting the rest to inactive
                                    if (ingreds.Count > j)
                                    { 
                                        ResetTableIngredient(prepIngredients[j], ingreds[j]); 
                                    }
                                    else { prepIngredients[j].SetActive(false); }
                                }
                                //Then sets the next inactive button to display the cooked dish.
                                prepIngredients[ingreds.Count + 1].SetActive(true);
                                ChangeButtonText(prepIngredients[ingreds.Count+1], recipes[i].dishName);
                                ChangeButtonImage(prepIngredients[ingreds.Count + 1], recipes[i].dishSprite);
                                sound.PlaySoundEffect(1);
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
        sound.PlaySoundEffect(0);
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
                ChangeButtonImage(prepIngredients[i], ingredient.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite);
                sound.PlaySoundEffect(0);

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
                ChangeButtonText(ovens[i], "Cooking: \n" + dish.GetComponentInChildren<TMP_Text>().text);

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
    /// Changes the image on the button to the image of the ingredient.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="newImage"></param>
    void ChangeButtonImage(GameObject button, Sprite newImage)
    {
        button.GetComponentInChildren<UnityEngine.UI.Image>().sprite = newImage;
    }

    void ResetTableIngredient(GameObject button, string ingredName)
    {
        button.GetComponentInChildren<TMP_Text>().text = ingredName;
        for (int i = 0; i < ingredientInfo.Count; i++)
        {
            if (ingredName == ingredientInfo[i].ingredientName)
            {
                button.GetComponentInChildren<UnityEngine.UI.Image>().sprite = ingredientInfo[i].ingredientImage;
            }
        }
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
