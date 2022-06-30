using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _MainMenu : MonoBehaviour
{
    public string startLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void OptionsGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Shutting Down");
    }
}
