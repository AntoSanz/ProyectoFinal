using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Opciones principales del menú
    public void StartGame()
    {
        SceneManager.LoadScene(texts.SCENE_1);
    }

    public void ShowOptionsMenu()
    {

    }

    public void ShowScenesMenu()
    {

    }

    public void ExitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    //Menu de opciones
}
