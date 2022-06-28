using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    float Damage;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage = Random.Range(10, 20);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Debug.Log("playerHealth");
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5);
    }

}
