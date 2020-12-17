using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    int highScoreStore1;
    int highScoreStore2;
    int highScoreStore3;
    int highScoreStore4;

    int mainScore;

    int scoreLeft;

    int scoreRequired = 80;

    public GameObject unlockButton;

    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;
    public TextMeshProUGUI highScore3;
    public TextMeshProUGUI highScore4;

    public TextMeshProUGUI mainScoreText;

    public TextMeshProUGUI scoreLeftText;


    // Start is called before the first frame update
    void Start()
    {
        highScoreStore1 = PlayerPrefs.GetInt("StoreHighScore" + 0);
        highScoreStore2 = PlayerPrefs.GetInt("StoreHighScore" + 1);
        highScoreStore3 = PlayerPrefs.GetInt("StoreHighScore" + 2);
        highScoreStore4 = PlayerPrefs.GetInt("StoreHighScore" + 3);

        mainScore = highScoreStore1 + highScoreStore2 + highScoreStore3 + highScoreStore4;

        scoreLeft = scoreRequired - mainScore;

        UpdateText();
    }

    void UpdateText()
    {
        highScore1.text = ("" + highScoreStore1);
        highScore2.text = ("" + highScoreStore2);
        highScore3.text = ("" + highScoreStore3);
        highScore4.text = ("" + highScoreStore4);

        mainScoreText.text = ("Score: " + mainScore);


        if(mainScore < scoreRequired)
        {
            scoreLeftText.text = ("Score " + scoreLeft + " more points to Unlock a Coupon!");
        }
        else
        {
            scoreLeftText.text = ("You have earned over " + scoreRequired + " points. Unlock the discount code!");
            unlockButton.SetActive(true);
        }
        
    }


}
