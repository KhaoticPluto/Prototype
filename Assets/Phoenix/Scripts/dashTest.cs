using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTest : MonoBehaviour
{
    // Player
    private Rigidbody _rb;
    public float _dashSpeed;
    private float _dashTime;
    public float _startDashTime;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _dashTime = _startDashTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _rb.velocity = Vector3.forward * _dashSpeed;
        }
        else
        {
            if(_dashTime <= 0)
            {
                _dashTime = _startDashTime;
                _rb.velocity = Vector3.zero;
            }
            else
            {
                _dashTime -= Time.deltaTime;
            }
        }
    }
}
