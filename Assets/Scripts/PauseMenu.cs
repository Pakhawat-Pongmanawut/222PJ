using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        Time.timeScale = 0f;// Freeze the game
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume normal time scale
    }

    public void Home(int mainMenuIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuIndex);
    }
}
