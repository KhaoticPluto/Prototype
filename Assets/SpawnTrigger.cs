using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    EnemyRoomSpawn _spawn;
    Collider _trigger;

    private void Start()
    {
        _spawn = GetComponent<EnemyRoomSpawn>();
        _trigger = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            _spawn.enabled = true;
            _trigger.enabled = false;
        }
    }

}
