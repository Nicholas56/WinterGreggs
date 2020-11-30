using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookDishScript : MonoBehaviour
{
    Image ovenButton;
    float cookTime = 5f;
    float timer;
    bool canClick;

    private void Awake()
    {
        ovenButton = GetComponent<Image>();
    }
    private void OnEnable()
    {
        timer = Time.time;
        canClick = false;
        ovenButton.color = Color.white;
    }

    private void Update()
    {
        if (Time.time > timer + cookTime)
        {
            CookingDone();
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

    /// <summary>
    /// The action to complete the food delivery
    /// </summary>
    public void DeliverProduct()
    {
        if (canClick)
        {
            //Whatever happens when a food is cooked. Score?
            gameObject.SetActive(false);
        }
    }
}
