using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenü : MonoBehaviour
{
  public static bool GamePaused = false;
  public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene(1);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1f;
    }
}

