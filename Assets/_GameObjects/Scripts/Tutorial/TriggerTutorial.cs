using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTutorial : MonoBehaviour
{
    public int triggerId;
    //[SerializeField] GameObject tutorialCanvas;
    [SerializeField] List<GameObject> canvasPanels;
    [SerializeField] Player playerScript;

    void Start()
    {
        PlayerAtackOff();
        ShowFirstTutorial();

    }

    private void ShowFirstTutorial()
    {
        canvasPanels[0].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(texts.TAG_PLAYER))
        {
            ShowTutorialCanvas(triggerId);
            DisableTutorialTrigger();
        }
    }

    private void ShowTutorialCanvas(int _triggerId)
    {
        Debug.Log("ShowTutorialCanvas: " + _triggerId);

        if (_triggerId == 2)
        {
            PlayerAtackOn();
        }
        PauseGame();
        canvasPanels[_triggerId].SetActive(true);
    }

    private void DisableTutorialTrigger()
    {
        this.gameObject.SetActive(false);
    }

    public void PlayerAtackOff()
    {
        playerScript.canAtack = false;
    }

    public void PlayerAtackOn()
    {
        playerScript.canAtack = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
