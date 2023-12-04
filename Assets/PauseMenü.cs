using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenü : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused) { 
                Resume();
            }
            else {
                Pause(); 
            }
        } 
    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
        move.isMovementAllowed = true;
        wall_trigger_script.generateRoad = true;
        lane_movement.currentLane = 1;
        move.speedIncreasementFactor = 1.0f;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1f;
    }
}

