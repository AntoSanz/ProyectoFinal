using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public bool isFinish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(texts.TAG_PLAYER))
        {
            SceneManager.LoadScene(texts.SCENE_ENDLEVEL, LoadSceneMode.Additive);
            TryToSavePoints();
        }
    }

    //Guardar los playerPrefs
    private void TryToSavePoints()
    {
        GameManager.TryToSavePoints();
    }
}
