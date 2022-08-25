using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenWeapon : MonoBehaviour
{

    float Damage;
    public int MaxDamage;
    public int MinDamage;

    public SphereCollider SphereCollider;

    private void Start()
    {
        StartCoroutine(TurnOffCollider());
    }
    IEnumerator TurnOffCollider()
    {
        yield return new WaitForSeconds(1);
        SphereCollider.GetComponent<SphereCollider>().enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Wareden Hits");

            Damage = Random.Range(MinDamage, MaxDamage);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);

        }
    }
}
