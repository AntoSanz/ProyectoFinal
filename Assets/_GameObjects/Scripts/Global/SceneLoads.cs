using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoads : MonoBehaviour
{
    void Awake()
    {
        LoadHUD();
    }
    private void LoadHUD()
    {
        SceneManager.LoadScene(texts.SCENE_HUD, LoadSceneMode.Additive);
    }
}