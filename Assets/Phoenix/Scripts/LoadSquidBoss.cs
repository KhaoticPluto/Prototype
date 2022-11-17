using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSquidBoss : MonoBehaviour
{
    public GameObject Text;
    bool inTrigger;

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LoadSceneManager.instance.LoadStartingArea();
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
