using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI highScore;

    private void Start() {
        YourScoreDisplay();
        HighScoreDisplay();
    }

    private void YourScoreDisplay(){
        yourScore.text = "Your Score: " + collision.score;
    }
    
    private void HighScoreDisplay(){
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void TryAgain(){
        SceneManager.LoadScene(0);
    }
}
