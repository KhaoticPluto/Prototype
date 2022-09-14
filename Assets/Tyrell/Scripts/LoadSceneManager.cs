using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    #region singleton
    public static LoadSceneManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    public void QuitGame()
    {
        ES3.Save("LastLevel", PlayerData.lastlevel);
        ES3.Save("CurrentXp", PlayerData.currentXp);

        Application.Quit();
    }

    // Restarts Game, sends it back to Start Level
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadWaveGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadRogueGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadStartingArea()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(4);
    }
}
