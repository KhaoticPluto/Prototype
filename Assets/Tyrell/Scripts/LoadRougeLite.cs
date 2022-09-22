using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRougeLite : MonoBehaviour
{
    public GameObject Text;
    bool inTrigger;

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadSceneManager.instance.LoadRogueGame();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(true);
            inTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(false);
            inTrigger = false;
        }

    }
}
