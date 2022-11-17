using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBargeSpawn : MonoBehaviour
{

    public Transform[] spawnZones; // Array filled with spawn zones transform

    public GameObject[] enemyPrefabs; // All available enemy prefabs stored here

    public List<GameObject> enemyList = new List<GameObject>();

    public SpawnTrigger _OnTrigger;

    public int maxEnemySpawn;

    int BaseEnemySpawn = 5;
    public int ExtraEnemies = 0;

    int bargeHealth = 400;
    int maxHP;
    int bargeXP = 100;

    public void FixedUpdate()
    {
        enemyList.RemoveAll(GameObject => GameObject == null);
    }

    void Start()
    {
        StartCoroutine(EnemyWait());
    }

    IEnumerator EnemyWait()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnBargeEnemies();
            Debug.Log("FIGHT");
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        Debug.Log("Remove Enemy");
        enemyList.Remove(enemy);
        if (enemyList.Count <= 0)
        {

            ShowNewItems();
        }

    }
    public int CalculateEnemySpawns()
    {
        int EnemiesToSpawn = 0;

        EnemiesToSpawn = BaseEnemySpawn + ExtraEnemies;

        return EnemiesToSpawn;
    }

    public void ShowNewItems()
    {
        Debug.Log("Shop");
        ShowItems.instance.ShowItemChoice();
        
    }

    public void SpawnBargeEnemies()
    {
        int spawnNum =Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, transform);
        Enemy.GetComponent<EnemyHealth>().MaxHealth += bargeHealth;
        Enemy.GetComponent<EnemyHealth>().Health += bargeHealth;
        Enemy.GetComponent<EnemyHealth>().XpGiven += bargeXP;
        Enemy.GetComponent<EnemyAiController>().IsRogueLite = true;
        Enemy.GetComponent<EnemyAiController>().bargespawn = this;
        enemyList.Add(Enemy);
    }
}
