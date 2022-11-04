using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBargeSpawn : EnemyRoomSpawn
{
    public float ExtraHealth = 35;
    public float XpGiven = 5;

    public override void Start()
    {
        StartCoroutine(WaitForPlayer());
    }

    public override void SpawnEnemies()
    {
        int spawnNum = Random.Range(0, spawnZones.Length);
        int enemyNum = Random.Range(0, enemyPrefabs.Length);

        GameObject Enemy = Instantiate(enemyPrefabs[enemyNum], spawnZones[spawnNum].transform.position, Quaternion.identity, transform);

        EnemyHealth enemyhealth = Enemy.GetComponent<EnemyHealth>();
        enemyhealth.MaxHealth += ExtraHealth;
        enemyhealth.Health = enemyhealth.MaxHealth;
        enemyhealth.XpGiven = XpGiven;

        Enemy.GetComponent<EnemyAiController>().roomspawn = this;
        Enemy.GetComponent<EnemyAiController>().IsRogueLite = true;
        enemyList.Add(Enemy);

    }
}
