using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScriptMap : MonoBehaviour
{
    bool helpOpen = false;

    public GameObject helpWindow;

    public GameObject helpText;

    public GameObject shopButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToStore1()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void goToStore2()
    {
        SceneManager.LoadScene("StoreScene 1");
    }

    public void goToStore3()
    {
        SceneManager.LoadScene("StoreScene 2");
    }

    public void goToStore4()
    {
        SceneManager.LoadScene("StoreScene 3"); 
    }

    public void goToMap()
    {
        SceneManager.LoadScene("MapScene v1.1");
    }

    public void OpenHelp()
    {
        if (helpOpen == false)
        {
            helpOpen = true;
            helpWindow.SetActive(true);
            helpText.SetActive(true);
            shopButtons.SetActive(false);
        }
        else
        {
            helpWindow.SetActive(false);
            helpText.SetActive(false);
            shopButtons.SetActive(true);
            helpOpen = false;
        }
    }
}
