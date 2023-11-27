using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    int score;
    static collision inst;
    [SerializeField] Text scoreText;
    [SerializeField] lane_movement lane_movement;

    //ScoreIncrement method to use later on collision with a NewCoin
    public void ScoreIncrement()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        // increase the moveSpeed of the Player when he collects a Coin
        lane_movement.moveSpeed += lane_movement.speedIncreasePerPoint;
    }
    private void Awake()
    {
        inst = this;
    }

    private void OnTriggerEnter(Collider other){
        //Check if the Player collides with an Ayran Bottle
        if(other.gameObject.CompareTag("AyranTag")){
            Debug.Log("Sexy Score");
        }
        //Check if the Player collides with a Coin
        if (other.gameObject.CompareTag("NewCoin"))
        {
            inst.ScoreIncrement();//increase Score by 1
            Destroy(other);//destroy Coin after collision
        }
    }
}
