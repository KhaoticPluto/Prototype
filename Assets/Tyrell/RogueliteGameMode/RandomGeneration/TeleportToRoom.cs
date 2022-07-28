using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRoom : MonoBehaviour
{
    public bool doorTouched;

    public RoomType roomType;

    [SerializeField]
    Vector3 pos;

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
                    RoomManager.instance.SpawnShopRoom();
                    
                    break;

                case RoomType.Loot:

                    break;
            }


            

            pos = RoomManager.instance.RoomSpawn[RoomManager.instance.RoomNumber - 1].transform.position;
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
