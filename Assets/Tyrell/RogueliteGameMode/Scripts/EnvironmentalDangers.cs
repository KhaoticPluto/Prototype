using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalDangers : MonoBehaviour
{
    public float Damage = 1;
    public float radius = 1;


    private void Start()
    {
        InvokeRepeating("DamageOverTime", 1, 1);
    }


    void DamageOverTime()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in hitColliders)
        {
            if (col.gameObject.tag == "Enemy")
            {

                col.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
                Vector3 enemyPos = new Vector3(col.gameObject.transform.position.x, 
                    col.gameObject.transform.position.y + 5, col.gameObject.transform.position.z);
                DamagePopUp.Create(enemyPos, Damage, false);
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
