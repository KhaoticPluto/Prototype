using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XpPointsUpgrade : MonoBehaviour
{

    public GameObject _canvas;
    public TextMeshProUGUI XpPoints;

    public GameObject Player;
    LevelSystem levelStats;
    Upgradeables upgradeStats;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        levelStats = Player.GetComponent<LevelSystem>();
        upgradeStats = Player.GetComponent<Upgradeables>();

        _canvas.SetActive(false);
    }

    private void Update()
    {
        XpPoints.text = "Lincoln Points: " + levelStats.EXPpoints ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(false);
        }
    }



}
