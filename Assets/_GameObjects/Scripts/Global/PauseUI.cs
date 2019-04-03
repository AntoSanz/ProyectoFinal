using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene(texts.SCENE_MAIN_MENU);
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(texts.SCENE_PAUSE);
    }
}
