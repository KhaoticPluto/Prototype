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

    public GameObject[] UpgradeRooms;
    public List<Transform> Rooms = new List<Transform>();

    public int RoomNumber;

    private void Start()
    {
        RoomNumber = 0;
    }

    public void SpawnUpgradeRoom()
    {
        int spawnedRoom = Random.Range(0, UpgradeRooms.Length);
        Instantiate(UpgradeRooms[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
        RoomNumber++;
        
    }



}


public enum RoomType
{
    Upgrade,
    Shop,
    Challenge,
    Loot,



}