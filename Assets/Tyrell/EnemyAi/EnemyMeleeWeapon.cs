using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeWeapon : MonoBehaviour
{
    float Damage;
    public float MaxDamage;
    public float MinDamage;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage = Random.Range(10, 20);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            

        }
    }
}
