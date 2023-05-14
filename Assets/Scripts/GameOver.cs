using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}