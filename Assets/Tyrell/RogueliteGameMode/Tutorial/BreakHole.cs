using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakHole : MonoBehaviour
{

    public Mesh _NormalWall;
    public Mesh _WallHole;

    public GameObject _wallBreakParticles;
    public Transform _particleSpawn;

    public Collider _boxCollider;

    bool alreadyBroken = false;

    public bool ChangeScene = false;

    private void Start()
    {
        GetComponent<MeshFilter>().mesh = _NormalWall;

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("PlayerBullet") && !alreadyBroken)
        {
            Debug.Log("Broke Wall");
            alreadyBroken = true;
            GetComponent<MeshFilter>().mesh = _WallHole;

            _boxCollider.GetComponent<BoxCollider>().enabled = false;
            GameObject wallbreak = Instantiate(_wallBreakParticles, _particleSpawn.position, Quaternion.identity);
            Destroy(wallbreak, 4f);

        }


    }
}
