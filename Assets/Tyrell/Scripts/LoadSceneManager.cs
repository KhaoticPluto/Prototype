using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    // Restarts Game, sends it back to Start Level
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
