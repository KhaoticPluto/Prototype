using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    #region singleton
    public static RoomManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public Transform[] RoomSpawn;

    public List<GameObject> RoomSpawnList = new List<GameObject>();

    public GameObject[] UpgradeRooms;
    public List<Transform> Rooms = new List<Transform>();

    public int RoomNumber = 0;

    private void Start()
    {
        RoomNumber = 0;
    }

    public void SpawnUpgradeRoom()
    {
        int spawnedRoom = Random.Range(0, UpgradeRooms.Length);
        Instantiate(RoomSpawnList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
        RoomNumber++;
        RoomSpawnList.RemoveAt(spawnedRoom);
    }



}


public enum RoomType
{
    Upgrade,
    Shop,
    Challenge,
    Loot,



}