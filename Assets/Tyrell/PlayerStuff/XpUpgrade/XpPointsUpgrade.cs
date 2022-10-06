using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XpPointsUpgrade : MonoBehaviour
{

    public GameObject _canvas;
    public GameObject _openCanvas;
    public TextMeshProUGUI XpPoints;

    bool inTrigger;

    public GameObject Player;
    LevelSystem levelStats;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        levelStats = Player.GetComponent<LevelSystem>();

        _openCanvas.SetActive(false);
        _canvas.SetActive(false);
    }

    private void Update()
    {
        XpPoints.text = "Lincoln Points: " + levelStats.EXPpoints ;

        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _canvas.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _openCanvas.SetActive(true);
            inTrigger = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
            _openCanvas.SetActive(false);
            _canvas.SetActive(false);
            GameManager.instance.DestroyItemInfo();
        }
    }



}
