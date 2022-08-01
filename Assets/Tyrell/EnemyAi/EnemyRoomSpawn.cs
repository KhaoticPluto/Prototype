using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomSpawn : MonoBehaviour
{
    #region singleton
    public static EnemyRoomSpawn instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    [SerializeField]
    private Transform[] spawnZones; // Array filled with spawn zones transform

    [SerializeField]
    private GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    [SerializeField]
    private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField]
    private int maxEnemySpawn;

    public Transform EnemyParent;


    public GameObject itemChoice;


    private void Start()
    {
        itemChoice.SetActive(false);

        maxEnemySpawn += RoomManager.instance.RoomNumber;

        RoomStart();
        
    }


    public void RoomStart()
    {
        for (int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnEnemies();
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        Debug.Log(enemy + "Removed");
        enemyList.Remove(enemy);
        Debug.Log(enemyList.Count);
        if (enemyList.Count <= 0)
        {
            
            ShowItemChoice();
        }
        
    }



    private void SpawnEnemies()
    {


        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, EnemyParent);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += RoomManager.instance.RoomNumber;
        Enemy.GetComponent<EnemyHealth>().Health += RoomManager.instance.RoomNumber;
        Enemy.GetComponent<EnemyAiController>().roomspawn = this;
        Enemy.GetComponent<EnemyAiController>().IsRogueLite = true;
        enemyList.Add(Enemy);



    }

    //Show Items After Room cleared



    public void ShowItemChoice()
    {
        itemChoice.SetActive(true);
        itemChoice.GetComponent<ItemChoice>().ShowItems();
        
    }

    public void DestroyItemChoice()
    {
        itemChoice.GetComponent<ItemChoice>().DestoryItems();
        itemChoice.SetActive(false);

    }
}
