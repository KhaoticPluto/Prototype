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

    //room prefabs
    public List<GameObject> UpgradeRoomList = new List<GameObject>();
    public List<GameObject> ShopRoomList = new List<GameObject>();
    public List<GameObject> ChallengeRoomList = new List<GameObject>();



    public int RoomNumber = 0;


    //Sets Player position at start of game
    public Transform player;
    Vector3 pos;
    float playerYPos = 2;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        RoomNumber = 0;
        
        pos = RoomSpawn[RoomNumber].transform.position;
        pos.y = playerYPos;

        player.transform.position = pos;

        SpawnUpgradeRoom();
    }

    public void Update()
    {
        
    }

    public void SpawnUpgradeRoom()
    {
        int spawnedRoom = Random.Range(0, UpgradeRoomList.Count);
        Instantiate(UpgradeRoomList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
        RoomNumber++;
        UpgradeRoomList.RemoveAt(spawnedRoom);
    }

    public void SpawnShopRoom()
    {
        int spawnedRoom = Random.Range(0, ShopRoomList.Count);
        Instantiate(ShopRoomList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
        RoomNumber++;
        

    }

    public void SpawnChallengeRoom()
    {

    }

    


}


public enum RoomType
{
    Upgrade,
    Shop,
    Challenge,
    Loot,



}