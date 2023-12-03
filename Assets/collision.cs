using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    public static int score;
    public static int highScore; //We pass the PlayerPrefs(HighScore) to this variable and then use it to show actual highScore
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
        //by each score increment we also check if current highScore in PlayerPrefs is exceeded
        HighScoreSet();
    }

    public void HighScoreSet()
    {
        //We pass the PlayerPrefs(HighScore) to int highScore
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        //We change the highScoreText to the PlayerPrefs(HighScore) with a String value of it
        highScoreText.text = "HighScore: " + highScore.ToString();
        //if the current score is greater than the HighScore in PlayerPrefs
        if (score > highScore){
        //We change the HighScore in PlayerPrefs with the new score
        PlayerPrefs.SetInt("HighScore", score);
        }
    }
    public static collision Instance { get; private set; }

    private void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        HighScoreSet();
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start(){
        //when we start we dont want to show highScore as 0 so we check the PlayerPrefs and show the old highScore
        HighScoreSet();
    }

    private void Update(){
        //each update checks if HighScore is exceeded
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
