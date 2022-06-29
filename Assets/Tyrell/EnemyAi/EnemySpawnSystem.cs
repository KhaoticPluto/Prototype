using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    public Vector3 Center;
    public Vector3 Size;

    public GameObject[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void SpawnEnemy()
    {
     

        

        GameObject newEnemy = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, Quaternion.identity);
    }

    Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();





        return position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(Center, Size);
    }
}
