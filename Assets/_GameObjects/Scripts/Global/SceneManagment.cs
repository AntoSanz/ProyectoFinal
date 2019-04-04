using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public static string IdToNameScene(int sceneId)
    {
        string sceneName = "";
        switch (sceneId)
        {
            case 0:
                sceneName = texts.SCENE_TUTORIAL;
                break;
            case 1:
                sceneName = texts.SCENE_1;
                break;
            case 2:
                sceneName = texts.SCENE_2;
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;

            default:
                break;
        }
        return sceneName;
    }
    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene(texts.SCENE_MAIN_MENU);
    }
}
