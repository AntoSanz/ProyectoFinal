using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    #region VAR
    private static int max_hp_player = 100;
    private const int POINTS_LENGTH = 6;
    private static int points = 0;
    private static string formatScore;
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
    }
    #endregion

    #region PRIVATE_FUNCTIONS

    #endregion
}
