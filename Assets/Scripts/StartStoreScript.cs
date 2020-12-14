using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStoreScript : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void BeginGame()
    {
        Time.timeScale = 1;
    }
}
