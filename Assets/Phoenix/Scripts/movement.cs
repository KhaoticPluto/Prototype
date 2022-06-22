using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 15;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;

    private void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
    }
    private void Look()
    {
        if (_input == Vector3.zero) return;

        Quaternion rot = Quaternion.LookRotation(_input, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
    //// Player
    //public float _moveSpeed = 10f;
    //public CharacterController controller;
    //private Vector3 _movement;

    //void Start()
    //{

    //}

    //private void Update()
    //{
    //    _movement.x = Input.GetAxisRaw("Horizontal");
    //    _movement.y = Input.GetAxisRaw("Vertical");
    //}

    //private void FixedUpdate()
    //{

    //}
}
