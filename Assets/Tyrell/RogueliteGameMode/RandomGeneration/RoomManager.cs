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
    public List<GameObject> HallWay = new List<GameObject>();
    public GameObject HallWayToBoss;



    public int RoomNumber = 0;


    //Sets Player position at start of game
    public Transform player;
    Vector3 pos;
    float playerYPos = 2;


    public GameObject BossRoom;
    public int BossRoomNumber;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        RoomNumber = 0;
        
        pos = RoomSpawn[RoomNumber].transform.position;
        pos.y = playerYPos;

        player.transform.position = pos;

        SpawnUpgradeRoom();
        
    }


    public void SpawnHallWay()
    {
        if (RoomNumber <= BossRoomNumber)
        {
            Instantiate(HallWay[0], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
            RoomNumber++;
        }
        else
        {
            Instantiate(HallWayToBoss, RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
            RoomNumber++;
        }

    }


    public void SpawnUpgradeRoom()
    {
        
            int spawnedRoom = Random.Range(0, UpgradeRoomList.Count);
            Instantiate(UpgradeRoomList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
            RoomNumber++;
            ///will remove spawned room so that it wil not spawn again
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
        int spawnedRoom = Random.Range(0, ChallengeRoomList.Count);
        Instantiate(ChallengeRoomList[spawnedRoom], RoomSpawn[RoomNumber].transform.position, Quaternion.identity);
        RoomNumber++;
    }

    public void SpawnBossRoom()
    {

        pos = RoomSpawn[RoomNumber].transform.position;
        pos.y = playerYPos;

        player.transform.position = pos;

        Instantiate(BossRoom, RoomSpawn[RoomNumber].transform.position, Quaternion.identity);

    }


}


public enum RoomType
{
    Upgrade,
    Shop,
    Challenge,
    Loot,



}