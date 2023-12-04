using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endGameScores : MonoBehaviour
{
    [SerializeField] TMP_Text endScoreText;
    [SerializeField] TMP_Text endHighScoreText;
    //public GameObject endGameMenuUI;
    private static int endScore;
    private static int endHighScore;

    void Start() {
        // (no) Changes just a comment for: finalCommit - Abgabe into master Branch
        endScore = collision.score;
        endHighScore = collision.highScore;

        endHighScoreText.text = "HighScore: " + endHighScore.ToString();
        endScoreText.text = "Score: " + endScore.ToString();
    }
}
