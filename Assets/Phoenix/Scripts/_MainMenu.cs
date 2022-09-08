using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class _MainMenu : MonoBehaviour
{


    public void StartGame()
    {
        if (PlayerData.TutorialComplete == true)
        {

            SceneManager.LoadScene(3);
        }
        else
        {
            StartTutorial();
        }
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene(4);
    }

}
