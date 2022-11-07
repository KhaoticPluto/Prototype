using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBarge : MonoBehaviour
{
    public Transform Destination;
    

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.transform.position = Destination.position;
        }
    }
}
