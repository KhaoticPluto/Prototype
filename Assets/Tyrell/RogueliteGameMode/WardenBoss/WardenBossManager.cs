using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class WardenBossManager : MonoBehaviour
{

    public bool PhaseTwo;


    //*************** Enemy Spawn variables
    float SpawnDelay = 5;
    public int SpawnedEnemies = 0;
    int NumberOfEnemiesToSpawn = 100;
    int EnemyHealthAdd = 0;
    public GameObject[] enemyPrefabs;
    public Transform[] spawnZones;
    public List<GameObject> enemyList = new List<GameObject>();
    //****************

    public GameObject _switch;

    public int boilerDestroyed = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemiesOverTime());
        PhaseTwo = false;
    }

    private void Update()
    {

        // enemy spawning
        enemyList.RemoveAll(GameObject => GameObject == null);

        if (enemyList.Count <= 0)
        {
            SpawnedEnemies = 0;
        }
        //enemy Spawning

        if(_switch.GetComponent<Switch>().leverSwitched &&
            boilerDestroyed >= 2)
        {
            PhaseTwo = true;
        }

        

    }













    /*******///enemy spawning code
    IEnumerator SpawnEnemiesOverTime()
    {

        SpawnedEnemies = 0;

        WaitForSeconds Wait = new WaitForSeconds(SpawnDelay);

        while (SpawnedEnemies < NumberOfEnemiesToSpawn)
        {

            SpawnRandomEnemy();

            SpawnedEnemies++;

            EnemyHealthAdd++;

            if (PhaseTwo)
            {
                foreach(GameObject enemy in enemyList)
                {
                    Destroy(enemy);
                }
                break;

            }

            yield return Wait;

        }
        
    }

        void SpawnRandomEnemy()
        {
            int spawnNum = Random.Range(0, spawnZones.Length);
            int enemyNum = Random.Range(0, enemyPrefabs.Length);

            GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, transform);
        // need a health scaler the scales over time maybe??
            Enemy.GetComponent<EnemyHealth>().MaxHealth += EnemyHealthAdd;
            Enemy.GetComponent<EnemyHealth>().Health += EnemyHealthAdd;
            enemyList.Add(Enemy);
        }
    /*********/
}
