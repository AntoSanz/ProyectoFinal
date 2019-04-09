using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoads : MonoBehaviour
{
    //private string sceneName;
    //private int sceneNumber;
    void Awake()
    {
        LoadHUD();
    }
    private void LoadHUD()
    {
        SceneManager.LoadScene(texts.SCENE_HUD, LoadSceneMode.Additive);
    }
    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene(texts.SCENE_GAMEOVER, LoadSceneMode.Additive);
    }
}