using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalDangers : MonoBehaviour
{
    public float Damage = 1;

    GameObject collided;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = other.gameObject;
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(DamageOverTime());
        }


    }

    IEnumerator DamageOverTime()
    {

        yield return new WaitForSeconds(1);
        collided.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
    }

}
