//using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    #region VAR
    private static int max_hp_player = 100;
    private const int POINTS_LENGTH = 6;
    private static int points = 0;
    private static string formatScore;
    private static Text pointsCount;
    //Variables que almacenan los playerprefs cargados
    public static int difficulty = 1;
    private static int unlockedLevels;
    private static string p0, p1, p2, p3;
    private int currentSceneNumber;

    //private static TextMeshPro textMeshPoints;
    #endregion

    #region GET_SET
    public static int Points {
        get {
            return points;
        }

        set {
            points = value;
        }
    }

    public static int Max_hp_player {
        get {
            return max_hp_player;
        }

        set {
            max_hp_player = value;
        }
    }


    #endregion

    #region PUBLIC_FUNCTIONS
    public static void AddPoints(int _points)
    {
        points = points + _points;
        ScoreToString(points);
    }

    public static void ScoreToString(int _score)
    {
        formatScore = _score.ToString();
        for (int i = 0; i < POINTS_LENGTH; i++)
        {
            if (i > formatScore.Length)
            {
                formatScore = "0" + formatScore;
            }
        }
        Debug.Log(formatScore);
        UpdatePointsUI(formatScore);
    }

    public static void UpdatePointsUI(string _formatScore)
    {
        //pointsCount.GetComponent<TextMeshPro>().text = _formatScore;
        pointsCount.text = _formatScore;
    }


    #endregion

    #region PRIVATE_FUNCTIONS
    private void Awake()
    {
        //Obtiene los playerprefs en cuanto se crea la scena para tenerlos disponibles en el start.
        GetPlayerPrefs();
    }

    private void Start()
    {
        pointsCount = GameObject.FindGameObjectWithTag(texts.TAG_POINTS).GetComponent<Text>();
        //Obtiene el nombre de la escena y lo transforma a integer (0 = tutorial, 1 = Scene1, 2 = Scene2) y lo almacena en "sceneNumber".
        //Ademas, si en los PlayerPrefs la ultima escena desbloqueada es menor que la escena en la que estamos, lo actualiza.
        GetSceneName();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(texts.SCENE_PAUSE, LoadSceneMode.Additive);
            PauseUI.PauseGame();
        }
    }

    private bool GetPlayerPrefs()
    {
        //Carga todos los playerprefs guardados, en caso de no existir, le da un valor por defecto.
        //difficulty = PlayerPrefs.GetInt(texts.PP_SELECTED_DIFICULTY_TEXT, texts.PP_SELECTED_DIFFICULTY_DEFAULT_VALUE);
        GetCurrentDifficulty();
        unlockedLevels = PlayerPrefs.GetInt(texts.PP_UNLOCKED_LEVELS_TEXT, texts.PP_UNLOCKED_LEVELS_DEFAULT_VALUE);
        p0 = PlayerPrefs.GetString(texts.PP_MAXPOINTS_0_TEXT, texts.PP_DEFAULT_POINTS_DEFAULT_VALUE);
        p1 = PlayerPrefs.GetString(texts.PP_MAXPOINTS_1_TEXT, texts.PP_DEFAULT_POINTS_DEFAULT_VALUE);
        p2 = PlayerPrefs.GetString(texts.PP_MAXPOINTS_2_TEXT, texts.PP_DEFAULT_POINTS_DEFAULT_VALUE);
        return true;
    }
    //private bool SetPlayerPrefs(int _dificulty, int _unlockedLevels, int _currentLevel, int _pointsInLevel)
    //{
    //    //Guardar siempre la dificultad. No es posible cambiarla cuando se empieza una partida con esa dificultad
    //    //Si el nivel que se acaba es superior al nivel que hay escrito, sobreescribir.
    //    //Si la puntuación del nivel seleccionado es mayor que la puntuacion que hay escrita, sobreescribir.
    //    return true;
    //}

    //private void SetDifficultyPP(int _dificulty)
    //{
    //    PlayerPrefs.SetInt(texts.PP_SELECTED_DIFICULTY_TEXT, _dificulty);
    //}

    //private static void SetUnlockedLevelsPP(int _unlockedLevels)
    //{
    //    PlayerPrefs.SetInt(texts.PP_UNLOCKED_LEVELS_TEXT, _unlockedLevels);
    //}

    /*GESTION DE LAS ESCENAS DESBLOQUEADAS*/
    //1. Obtener el nombre de la escena actual.
    private void GetSceneName()
    {
        string sceneName = SceneManager.GetActiveScene().name; //Obtener el nombre (string) de la escena.
        SceneNameToInt(sceneName);
    }
    //2.Cambiar el nombre de la escena por un número.
    private void SceneNameToInt(string _sceneName)
    {
        //Cambiar el string con el nombre de la escena por un número para saber hasta donde tenemos desbloqueado
        switch (_sceneName)
        {
            case texts.SCENE_TUTORIAL:
                currentSceneNumber = 0;
                break;
            case texts.SCENE_1:
                currentSceneNumber = 1;
                break;
            case texts.SCENE_2:
                currentSceneNumber = 2;
                break;
            default:
                break;
        }
        CompareUnlockScenes();
    }
    //3. Comparar el número de la escena en la que estamos por el máximo que hemos desbloqueado
    private void CompareUnlockScenes()
    {
        if (unlockedLevels < currentSceneNumber)
        {
            unlockedLevels = currentSceneNumber;
        }
    }

    /*GESTION DE LAS PUNTUACIONES*/
    //LLamar cuando acabamos el nivel para comprobar si guardamos o no los puntos.
    public void TryToSavePoints()
    {
        SetMaxPoints(currentSceneNumber, formatScore);
    }

    //Guarda los puntos maximos obtenidos en un nivel
    private void SetMaxPoints(int _level, string _points)
    {
        //Comprobamos si hay que almacenar la puntuación conseguida
        bool save = ComparePoints(_level, _points);
        if (save == false)
            return;

        switch (_level)
        {
            case 0:
                PlayerPrefs.SetString(texts.PP_MAXPOINTS_0_TEXT, _points);
                break;
            case 1:
                PlayerPrefs.SetString(texts.PP_MAXPOINTS_1_TEXT, _points);
                break;
            case 2:
                PlayerPrefs.SetString(texts.PP_MAXPOINTS_2_TEXT, _points);
                break;
            default:
                Debug.Log("Error al guardar la puntuación");
                break;
        }
    }

    //Comparar los puntos maximos y lo sconseguidos de un nivel. Devuelve TRUE si los puntos obtenidos son mayores que los almacenados en el PlayerPrefs
    private bool ComparePoints(int _level, string _points)
    {
        bool save = false;
        int x;
        int.TryParse(_points, out x); //Parseamos el string de la puntuación a integer;

        //Comparamos el integer de la puntuación obtenida con la que queremos guardar
        if (x > Points)
        {
            save = false; // Si la puntuación es menor, return false para que no guarde nada.
        }
        else
        {
            return true; //Si la puntuación es mayor, return true.
        }

        return save;

    }

    /*GESTION DE LA DIFICULTAD*/
    //Obtiene la dificultad que habíamos seleccionado
    private void GetCurrentDifficulty()
    {
        difficulty = PlayerPrefs.GetInt(texts.PP_SELECTED_DIFICULTY_TEXT, texts.PP_SELECTED_DIFFICULTY_DEFAULT_VALUE);
    }
    //Cambia la dificultad a la que hemos seleccionado en el menu principal.
    public static void ChangeDifficulty(int _difficultyId)
    {
        difficulty = _difficultyId;
        PlayerPrefs.SetInt(texts.PP_SELECTED_DIFICULTY_TEXT, _difficultyId);
    }
    #endregion
}
