using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class _MainMenu : MonoBehaviour
{


    public void StartGame()
    {

            SceneManager.LoadScene(3);
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene(4);
    }

}
