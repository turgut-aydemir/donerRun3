using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    public static int score = 0;
    public static int highScore = 0;
    static collision inst;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] lane_movement lane_movement;

    //ScoreIncrement method to use later on collision with a NewCoin
    public void ScoreIncrement()
    {
        score++;
        scoreText.text = "Score: " + score;
        // increase the moveSpeed of the Player when he collects a Coin
        lane_movement.moveSpeed += lane_movement.speedIncreasePerPoint;
    }

    public void HighScoreSet()
    {
        //if (score > PlayerPrefs.GetInt(HighScore)){
        if (score > highScore){
        //PlayerPrefs.SetInt(highScore, score);
        highScore = score;
        highScoreText.text = "HighScore: " + highScore;
    }}
    public static collision Instance { get; private set; }

    private void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();

        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update(){
        HighScoreSet();
    }

    private void OnTriggerEnter(Collider other){
        //Check if the Player collides with an Ayran Bottle
        
        //Check if the Player collides with a Coin
        if (other.gameObject.CompareTag("NewCoin"))
        {
            Debug.Log("Sexy Score");
            Instance?.ScoreIncrement();//increase Score by 1
            Destroy(other.gameObject);//destroy Coin after collision
        }
    }
}
