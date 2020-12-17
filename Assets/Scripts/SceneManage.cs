using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [Tooltip("The scene that will be unloaded when new scene is loaded")]
    public int currentScene;

    /// <summary>
    /// Loads the input scene and unloads the previous scene. Also moves the gameManager to new scene.
    /// </summary>
    /// <param name="sceneNumber"></param>
    public void GoToScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);

        //Load gameManager into new scene

    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
