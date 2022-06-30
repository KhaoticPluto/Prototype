using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawnSystem : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnZones; // Array filled with spawn zones transform

    [SerializeField]
    private GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private int maxEnemySpawn;

    public bool coroutineRunning;

    public Transform EnemyParent;


    public int WaveNumber;
    public int MaxWaves;
    public bool StartedWaves;
    public bool nextWave;
    float NextWaveTimer = 5;
    float resetTimer = 5;

    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI NextWaveText;


    private void Start()
    {
        StartedWaves = false;
        StartWave();

    }

    private void Update()
    {
        WaveText.text = "Wave : " + WaveNumber;
        
        if(nextWave)
        {
            NextWaveTimer -= Time.deltaTime;
            NextWaveText.gameObject.SetActive(true);
            DisplayTime(NextWaveTimer);
            
        }
        else
        {
            NextWaveText.gameObject.SetActive(false);
            NextWaveTimer = resetTimer;
        }
        


        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemies();
        }

        if(enemyList.Count == 0 && StartedWaves == true)
        {
            nextWave = true;
            Invoke("NextWave", 5);
            
            StartedWaves = false;
        }

        enemyList.RemoveAll(GameObject => GameObject == null);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        NextWaveText.text = "Next Wave " + string.Format("{1:00}", minutes, seconds);
    }

    void StartWave()
    {
        StartedWaves = true;
        WaveNumber = 1;
        maxEnemySpawn = 2;

        for(int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnEnemies();
        }
        


    }

    void NextWave()
    {
        WaveNumber++;
        maxEnemySpawn = maxEnemySpawn + 2 + WaveNumber;
        StartedWaves = true;
        nextWave = false;
            for (int i = 0; i < maxEnemySpawn; i++)
            {
                SpawnEnemies();
            }

        
    }
    
    //IEnumerator SpawnEnemiesDelay()
    //{
    //    yield return new WaitForSeconds(5);

    //    int spawnNum = Random.Range(0, spawnZones.Length);
    //    int enemyNum = Random.Range(0, enemyPrefabs.Length);

    //    GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
    //    Enemy.GetComponent<EnemyHealth>().EnemyGainHealth(WaveNumber);
    //    Debug.Log(Enemy.GetComponent<EnemyHealth>().Health);
    //    enemyList.Add(Enemy);

    //}

    private void SpawnEnemies()
    {


        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<EnemyHealth>().EnemyGainHealth(WaveNumber);
        enemyList.Add(Enemy);
        


    }

    


}
