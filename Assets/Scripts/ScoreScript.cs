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

    public void IncreaseScore()
    {
        scoreNum++;
        scoreTxt.text = "Score: " + scoreNum;
    }
}
