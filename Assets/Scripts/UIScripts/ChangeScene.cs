using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void ChangingScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            if (SceneUtility.GetBuildIndexByScenePath(sceneName) != -1)
            {
                SceneManager.LoadScene(sceneName);
                Time.timeScale = 1;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Cerranding");
    }
}
