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
    private void Start()
    {
        //sceneName = SceneManager.GetActiveScene().name;
        //GameManager.GetPlayerPrefs();
        //GameManager.SetUnlockedLevelsPP(sceneNumber);
    }
    private void LoadHUD()
    {
        SceneManager.LoadScene(texts.SCENE_HUD, LoadSceneMode.Additive);
    }
    //private void ReturnSceneNumber()
    //{
    //    switch (sceneName)
    //    {
    //        case texts.SCENE_TUTORIAL:
    //            sceneNumber = 0;
    //            break;
    //        case texts.SCENE_1:
    //            sceneNumber = 1;
    //            break;
    //        case texts.SCENE_2:
    //            sceneNumber = 2;
    //            break;
    //        default:
    //            break;
    //    }
    //}
}