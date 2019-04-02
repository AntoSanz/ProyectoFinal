using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] Dropdown dropdownDif;
    [SerializeField] Dropdown dropdownLevel;
    private int unlockedLevels;
    private string sceneSelected;

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

    public void SelectDif()
    {

        int dif;
        switch (dropdownDif.value)
        {
            case 0:
                dif = 1;
                break;
            case 1:
                dif = 2;
                break;
            default:
                dif = 1;
                break;
        }
        GameManager.ChangeDifficulty(dif);
    }

    public void LoadCustomScene()
    {
        switch (dropdownLevel.value)
        {
            case 0:
                //SceneManager.LoadScene(texts.SCENE_TUTORIAL);
                sceneSelected = texts.SCENE_TUTORIAL;
                break;
            case 1:
                //SceneManager.LoadScene(texts.SCENE_1);
                sceneSelected = texts.SCENE_1;
                break;
            default:
                //SceneManager.LoadScene(texts.SCENE_TUTORIAL);
                sceneSelected = texts.SCENE_TUTORIAL;
                break;
        }
    }
    public void GoCustomScene()
    {
        if (sceneSelected == null)
        {
            sceneSelected = texts.SCENE_TUTORIAL;
        }
        SceneManager.LoadScene(sceneSelected);
    }
    //Menu de opciones
}
