using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    public Animator animator;

    public void LoadWaveGame()
    {
        StartCoroutine(LoadWaveLevel());
    }

    public void LoadRogueGame()
    {
        StartCoroutine (LoadRogueLevel());
    }

    IEnumerator LoadWaveLevel()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        LoadSceneManager.instance.LoadWaveGame();
    }

    IEnumerator LoadRogueLevel()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds (1);

        LoadSceneManager.instance.LoadRogueGame();
    }

}
