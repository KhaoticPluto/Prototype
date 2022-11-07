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


}
