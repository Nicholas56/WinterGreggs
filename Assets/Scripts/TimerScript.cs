using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float fullTime = 120f;
    TMP_Text timerTxt;
    public GameObject endPanel;
    float timeCount;
    bool gameEnd = false;
    SoundManager sound;

    private void Awake()
    {
        timerTxt = GetComponent<TMP_Text>();
        timerTxt.text = "" + timeCount.ToString("N0") + "/" + fullTime.ToString("N0") + "s";
        sound = FindObjectOfType<SoundManager>();
    }

    private void LateUpdate()
    {
        timeCount += Time.deltaTime;
        timerTxt.text = "" + timeCount.ToString("N0") + "/" + fullTime.ToString("N0") + "s";
        timeCount = Mathf.Min(timeCount, fullTime);
        //Changes the color to red as time runs out
        timerTxt.color = Color.Lerp(Color.black, Color.red, (timeCount / fullTime));

        if (timeCount >= fullTime&&!gameEnd)
        {
            endPanel.SetActive(true); gameEnd = true;
            sound.PlaySoundEffect(4);
        }
    }
}
