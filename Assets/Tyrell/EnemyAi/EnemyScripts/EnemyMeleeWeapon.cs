using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeWeapon : MonoBehaviour
{
    float Damage;
    public int MaxDamage;
    public int MinDamage;
    bool alreadyDamaged;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Wareden Hits");
            if (!alreadyDamaged)
            {
                Damage = Random.Range(MinDamage, MaxDamage);
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            }
            else
            {
                Debug.Log("alreadyDamage");
                alreadyDamaged = true;
                StartCoroutine(AlreadyAttacked());
            }
            
            

        }
    }

    IEnumerator AlreadyAttacked()
    {
        yield return new WaitForSeconds(.5f);
        alreadyDamaged = false;
        
    }
}
