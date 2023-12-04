using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    public Animator animator;
    private Transform Player;
    private AudioSource audioSource;
    private AudioSource audioSource2;

    static collision inst;
    private int puddleContact = 0;
    private int score = 0;
    public static int highScore; //We pass the PlayerPrefs(HighScore) to this variable and then use it to show actual highScore
    public float initialSpeed = 6f;
    public float speedIncrement = 1.1f;
    public float maxSpeed = 36f;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] lane_movement lane_movement;


    // Start is called before the first frame update
    void Start()
    {
        GameObject doenerMann = GameObject.Find("Donermannblend");
        Player = GetComponent<Transform>();
        animator = doenerMann.GetComponent<Animator>();
        audioSource = GameObject.Find("AudioItems").GetComponent<AudioSource>();
        audioSource2 = GameObject.Find("AudioGameover").GetComponent<AudioSource>();
        //Call periodically to increase score
        InvokeRepeating("IncreasePoints", 0f, 2f);
        //We check HighScore at the Start to show on the main playScreen
        HighScoreSet();
    }
        

        public void ScoreIncrement()
    {
        this.score += 5;
        scoreText.text = "Score: " + this.score;
    
    }

    public void HighScoreSet()
    {
        //We pass the PlayerPrefs(HighScore) to int highScore
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        //We change the highScoreText to the PlayerPrefs(HighScore) with a String value of it
        highScoreText.text = "HighScore: " + highScore.ToString();
        //if the current score is greater than the HighScore in PlayerPrefs
        if (score > highScore)
        {
            //We change the HighScore in PlayerPrefs with the new score
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public static collision Instance { get; private set; }

    private void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<TMP_Text>();
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //each Frame update checks if HighScore is exceeded to show it directly during game
        HighScoreSet();
    }

    private void OnTriggerEnter(Collider other){
       
        if (other.gameObject.CompareTag("NewCoin"))
        {
            audioSource.Play();
            this.score += 5;
            scoreText.text = "Score: " + this.score;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Ayrab"))
        {
            audioSource.Play();
            this.score += 50;
            scoreText.text = "Score: " + this.score;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Trashcan") ||
            other.gameObject.CompareTag("Bird") ||
            other.gameObject.CompareTag("Rat") ||
            other.gameObject.CompareTag("Pothole"
            ))
        {
            playGameOverAnimation();

        }

        if (other.gameObject.CompareTag("Puddle"))
        {
            if (puddleContact == 1)
            {
                playGameOverAnimation();
                
            }
            else
            {
                animator.Play("DonerMannChaseAnim", 0, 0.0f);
                puddleContact++;
            }
        }

    }

    private void IncreasePoints()
    {
        if (move.isMovementAllowed)
        {
            score++;
            scoreText.text = "Score: " + score;
            if (score % 5 == 0)
            {
                move.speedIncreasementFactor += 2.0f;
            }
        }
        
    }

    private void playGameOverAnimation() {
        audioSource2.Play();
        wall_trigger_script.generateRoad = false;
        move.isMovementAllowed = false;

        if (lane_movement.currentLane == 0)
        {
            animator.Play("ChaseRightAnim", 0, 0.0f);
        }
        else if (lane_movement.currentLane == 1)
        {
            animator.Play("ChaseMidAnim", 0, 0.0f);
        }
        else
        {
            animator.Play("ChaseLeftAnim", 0, 0.0f);
        }
        PlayerPrefs.Save();
        StartCoroutine(EndGameWaiter());
        IEnumerator EndGameWaiter()
        {
            yield return new WaitForSeconds(3);
        }
        SceneManager.LoadScene(2);
    }

   
}
