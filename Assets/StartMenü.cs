using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenü : MonoBehaviour
{
    public GameObject startMenuUI;

    private void Start()
    {
        startMenuUI.SetActive(false);
    }

    // Play button will start the 1st Level
    public void OnPlayButton()
    {
        collision.score = 0;
        SceneManager.LoadSceneAsync(1);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    // Quit button exits the app
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
