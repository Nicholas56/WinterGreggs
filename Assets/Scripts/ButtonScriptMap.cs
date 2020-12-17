using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScriptMap : MonoBehaviour
{
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
}
