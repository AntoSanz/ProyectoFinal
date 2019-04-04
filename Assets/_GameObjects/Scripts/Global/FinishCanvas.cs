using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishCanvas : MonoBehaviour
{
    [SerializeField] GameObject healthpointsInput;
    [SerializeField] GameObject scoreInput;

    private void Start()
    {
        ShowScore();
        ShowHealthPoints();
    }
    public void NextLevel()
    {
        Debug.Log("CurrentScene: " + GameManager.currentSceneNumber);
        int sceneToLoadId = GameManager.currentSceneNumber + 1;
        //Debug.Log("SceneToLoad: " + sceneToLoadId);
        string sceneToLoadName = SceneManagment.IdToNameScene(sceneToLoadId);
        SceneManager.LoadScene(sceneToLoadName);

    }
    public void GoMainMenu()
    {
        SceneManagment.LoadMainMenuScene();
    }

    private void ShowScore()
    {
        string score = GameManager.formatScore;
        scoreInput.GetComponent<TextMeshProUGUI>().text = score;

    }
    private void ShowHealthPoints()
    {
        string hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currentHp.ToString();
        healthpointsInput.GetComponent<TextMeshProUGUI>().text = hp;
        
    }
}
