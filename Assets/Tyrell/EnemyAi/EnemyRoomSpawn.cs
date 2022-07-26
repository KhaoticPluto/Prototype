using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnZones; // Array filled with spawn zones transform

    [SerializeField]
    private GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private int maxEnemySpawn;


    [SerializeField]
    private int enemiesSpawned = 0;

    public Transform EnemyParent;




    private void Start()
    {
        enemiesSpawned = 0;

        //send Analytics When game starts
        Analytics.instance.GameStartAnalytics();
        maxEnemySpawn += RoomManager.instance.RoomNumber;
        
        
        
    }

    private void Update()
    {
        if (enemiesSpawned < maxEnemySpawn)
        {
            SpawnEnemies();
            enemiesSpawned++;
        }

        enemyList.RemoveAll(GameObject => GameObject == null);
    }





    private void SpawnEnemies()
    {


        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += RoomManager.instance.RoomNumber;
        Enemy.GetComponent<EnemyHealth>().Health += RoomManager.instance.RoomNumber;
        enemyList.Add(Enemy);



    }
}
