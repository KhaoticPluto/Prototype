using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudVariant : HUDManager
{
    public EnemySpawnSystem EnemySpawn;

    public TextMeshProUGUI NextWaveText;
    public TextMeshProUGUI WaveText;

    private void Start()
    {
        EnemySpawn = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawnSystem>();
    }


    private void Update()
    {
        //Wave Text
        WaveText.text = "Wave : " + EnemySpawn.WaveNumber;
        if (EnemySpawn.nextWave)
        {

            EnemySpawn.NextWaveTimer -= Time.deltaTime;
            NextWaveText.gameObject.SetActive(true);
            DisplayTime(EnemySpawn.NextWaveTimer);
            if (EnemySpawn.showItems)
            {
                EnemySpawn.ShowItemChooser();
                EnemySpawn.showItems = false;
            }

        }
        else
        {
            NextWaveText.gameObject.SetActive(false);
            EnemySpawn.NextWaveTimer = EnemySpawn.resetTimer;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        NextWaveText.text = "Next Wave " + string.Format("{1:00}", minutes, seconds);
    }
}
