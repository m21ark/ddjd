using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseCanvas;
    
    public void StartGame_Single()
    {
        SceneManager.LoadScene("Game_SinglePlayer");
        if(isGamePaused) ResumeGame();
    }

    public void StartGame_Multi()
    {
        SceneManager.LoadScene("Game_MultiPlayer");
        if(isGamePaused) ResumeGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        if(pauseCanvas != null)
        pauseCanvas.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        if(pauseCanvas != null)
        pauseCanvas.SetActive(true);
    }

    public void TogglePauseGame()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}
