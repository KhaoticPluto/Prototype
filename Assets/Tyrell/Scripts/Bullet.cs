using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float Damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "WhatIsWall")
        {
            Debug.Log("Hit Wall");
            rb.velocity = Vector3.zero;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);


        }
    }

}
