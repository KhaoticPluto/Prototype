using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRoom : MonoBehaviour
{
    public bool doorTouched;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && !doorTouched)
        {
            RoomManager.instance.SpawnUpgradeRoom();

            Vector3 pos = RoomManager.instance.RoomSpawn[RoomManager.instance.RoomNumber - 1].transform.position;
            pos.y = 3;

            other.transform.position = pos;
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
