using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class _MainMenu : MonoBehaviour
{
    public UnityEvent interactEVNT;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartRun()
    {
        SceneManager.LoadScene(3);
    }

    public void OptionsGame()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
