using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTest : MonoBehaviour
{
    // Player
    private Rigidbody _rb;
    private float _dashTime;
    public float _startDashTime;
    private Vector3 _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _dashTime = _startDashTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
        }
        
    }

    
}
