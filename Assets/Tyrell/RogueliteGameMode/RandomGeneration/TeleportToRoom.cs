using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRoom : MonoBehaviour
{
    public bool doorTouched;

    public RoomType roomType;


    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player" && !doorTouched)
        {
            switch (roomType)
            {

                case RoomType.Upgrade:
                    RoomManager.instance.SpawnUpgradeRoom();
                    break;

                case RoomType.Shop:

                    break;

                case RoomType.Loot:

                    break;
            }


            

            Vector3 pos = RoomManager.instance.RoomSpawn[RoomManager.instance.RoomNumber - 1].transform.position;
            pos.y = 3;

            other.transform.position = pos;
            doorTouched = true;
            DestroyRoom();
            StartCoroutine(DoorReset());
        }


    }

    IEnumerator DoorReset()
    {
        yield return new WaitForSeconds(5);
        doorTouched = false;
        
    }


    void DestroyRoom()
    {

        Destroy(transform.parent.gameObject);

    }

}
