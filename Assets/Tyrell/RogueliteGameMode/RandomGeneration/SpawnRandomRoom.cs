using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomRoom : MonoBehaviour
{
    public static Transform LastRoom;

    

    public Transform[] Rooms;
    public List<Transform> RoomSpawns = new List<Transform>();

    public bool doorTouched;

    int RoomNumber;

    private void OnTriggerStay(Collider other)
    {
        RoomNumber = Random.Range(0, RoomSpawns.Count);
        if (other.gameObject.tag == "Player" && !doorTouched)
        {
            LastRoom = other.transform;
            other.transform.position = RoomSpawns[RoomNumber].transform.position;
            RoomSpawns.Remove(RoomSpawns[RoomNumber]);
            doorTouched = true;
            StartCoroutine(DoorReset());
        }


    }

    IEnumerator DoorReset()
    {
        yield return new WaitForSeconds(5);
        doorTouched = false;
    }

}
