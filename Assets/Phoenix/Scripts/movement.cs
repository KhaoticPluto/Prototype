using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Dash Terms
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    // Player Movement Terms
    [SerializeField] private Rigidbody _rb;
    [SerializeField] public float _speed = 15;
    [SerializeField] private Transform _model;
    private Vector3 moveDirection;

    private Vector3 _input;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        // Inputs
        _input.x = Input.GetAxis("Horizontal");
        _input.z = Input.GetAxis("Vertical");

        moveDirection = new Vector3(_input.x, 0, _input.z).normalized;

        // Dash Inputs
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }

        //Look();
    }

    private void FixedUpdate()
    {
        // Movement
        _rb.velocity = new Vector3(moveDirection.x * _speed,0, moveDirection.z * _speed);
    }

    //private void Look()
    //{
    //    if (_input == Vector3.zero) return;

    //    Quaternion rot = Quaternion.LookRotation(_input, Vector3.up);
    //    _model.rotation = Quaternion.RotateTowards(_model.rotation, rot, _speed * Time.deltaTime);
    //}
}
