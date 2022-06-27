using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    // Player Movement Terms
    [SerializeField] public CharacterController controller;
    [SerializeField] public float _speed = 15;
    public Vector3 _moveDirection;

    private void Start()
    {
        
    }

    private void Update()
    {
        // Inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _moveDirection = new Vector3(horizontal, 0, vertical).normalized;


        if (_moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(_moveDirection * _speed * Time.deltaTime);
        }

        
    }

    private void FixedUpdate()
    {
        // Movement
        
    }

    //private void Look()
    //{
    //    if (_input == Vector3.zero) return;

    //    Quaternion rot = Quaternion.LookRotation(_input, Vector3.up);
    //    _model.rotation = Quaternion.RotateTowards(_model.rotation, rot, _speed * Time.deltaTime);
    //}
}
