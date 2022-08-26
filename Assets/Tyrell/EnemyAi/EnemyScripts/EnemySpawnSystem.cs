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

    public bool showItems;

    public int WaveNumber;
    public int MaxWaves;
    public bool StartedWaves;
    public bool nextWave;
    public float NextWaveTimer = 5;
    public float resetTimer = 5;




    public WaveGameManager manager;


    private void Start()
    {
        StartedWaves = false;
        StartWave();

        //send Analytics When game starts
        //Analytics.instance.GameStartAnalytics();

        //find game manager
        manager = FindObjectOfType<WaveGameManager>();
        manager.GetComponent<GameManager>();
    }

    private void Update()
    {
        manager.WavesCompleted = WaveNumber - 1;


        

        if(enemyList.Count == 0 && StartedWaves == true)
        {
            nextWave = true;
            showItems = true;
            Invoke("NextWave", 5);
            
            StartedWaves = false;
        }

        enemyList.RemoveAll(GameObject => GameObject == null);
    }

    public void ShowItemChooser()
    {
        manager.ShowItemChoice();
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



    IEnumerator SpawnEnemiesWait()
    {
        
        Debug.Log("spawned enemy");
        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += RoomManager.instance.RoomNumber;
        Enemy.GetComponent<EnemyHealth>().Health += RoomManager.instance.RoomNumber;
        enemyList.Add(Enemy);
        yield return new WaitForSeconds(.2f);
    }

    private void SpawnEnemies()
    {


        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += WaveNumber;
        Enemy.GetComponent<EnemyHealth>().Health += WaveNumber;
        enemyList.Add(Enemy);
        


    }

    


}