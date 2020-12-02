using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookDishScript : MonoBehaviour
{
    Image ovenButton;
    float cookTime = 5f;
    float burnTime = 8f;
    float timer;
    bool canClick;
    bool burnt;

    ScoreScript score;

    private void Awake()
    {
        ovenButton = GetComponent<Image>();
        score = FindObjectOfType<ScoreScript>();
    }
    private void OnEnable()
    {
        timer = Time.time;
        canClick = false;
        burnt = false;
        ovenButton.color = Color.white;
    }

    private void Update()
    {
        if (Time.time > timer + cookTime &&!canClick)
        {
            CookingDone();
        }
        if (Time.time > timer + burnTime &&!burnt)
        {
            Burnt();
        }
    }

    /// <summary>
    /// Makes changes to alert the player of the completed food
    /// </summary>
    void CookingDone()
    {
        ovenButton.color = Color.red;
        canClick = true;
    }

    void Burnt()
    {
        ovenButton.color = Color.black;
        burnt = true;
    }

    /// <summary>
    /// The action to complete the food delivery
    /// </summary>
    public void DeliverProduct()
    {
        if (canClick)
        {
            if (!burnt)
            {
                score.IncreaseScore(gameObject.GetComponentInChildren<TMPro.TMP_Text>().text);
            }
            //Whatever happens when a food is cooked. Score?
            gameObject.SetActive(false);
        }
    }
}
