using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public static void ChangeDifficulty(int _dif)
    {
        difficulty = _dif;
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void Start()
    {
        pointsCount = GameObject.FindGameObjectWithTag(texts.TAG_POINTS).GetComponent<Text>();
    }
    private bool GetPlayerPrefs()
    {
        //Carga todos los playerprefs guardados, en caso de no existir, le da un valor por defecto.
        difficulty = PlayerPrefs.GetInt(texts.PP_SELECTED_DIFICULTY_TEXT, texts.PP_SELECTED_DIFFICULTY_DEFAULT_VALUE);
        unlockedLevels = PlayerPrefs.GetInt(texts.PP_UNLOCKED_LEVELS_TEXT, texts.PP_UNLOCKED_LEVELS_DEFAULT_VALUE);
        p0 = PlayerPrefs.GetString(texts.PP_MAXPOINTS_0_TEXT, texts.PP_DEFAULT_POINTS_DEFAULT_VALUE);
        p1 = PlayerPrefs.GetString(texts.PP_MAXPOINTS_1_TEXT, texts.PP_DEFAULT_POINTS_DEFAULT_VALUE);
        p2 = PlayerPrefs.GetString(texts.PP_MAXPOINTS_2_TEXT, texts.PP_DEFAULT_POINTS_DEFAULT_VALUE);
        return true;
    }
    public bool SetPlayerPrefs(int _dificulty, int _unlockedLevels, int _currentLevel, int _pointsInLevel)
    {
        //Guardar siempre la dificultad. No es posible cambiarla cuando se empieza una partida con esa dificultad
        //Si el nivel que se acaba es superior al nivel que hay escrito, sobreescribir.
        //Si la puntuación del nivel seleccionado es mayor que la puntuacion que hay escrita, sobreescribir.
        return true;
    }
    private void SetDifficultyPP(int _dificulty)
    {
        PlayerPrefs.SetInt(texts.PP_SELECTED_DIFICULTY_TEXT, _dificulty);
    }
    private void SetUnlockedLevelsPP(int _unlockedLevels)
    {
        PlayerPrefs.SetInt(texts.PP_UNLOCKED_LEVELS_TEXT, _unlockedLevels);
    }
    private void SetMaxPoints(int _level, string _points)
    {
        bool save = ComparePoints(_level, _points);
        if (save == false)
            return;

        switch (_level)
        {
            case 0:

                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }
    private bool ComparePoints(int _level, string _points)
    {
        bool save = false;
        //Parseamos el string de la puntuación a integer;
        int x;
        Int32.TryParse(_points, out x);

        //Comparamos el integer de la puntuación obtenida con la que queremos guardar
        if (x > Points)
        {
            //Si la puntuación es menor, return false para que no guarde nada.
            save = false;
        }
        else
        {
            //Si la puntuación es mayor, return true.
            return true;
        }

        return save;

    }
    #endregion
}
