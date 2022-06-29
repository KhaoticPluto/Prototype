using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //Camera
    private Camera mainCam;
    [SerializeField] private LayerMask ground;

    // Player Movement Terms
    [SerializeField] public CharacterController controller;
    [SerializeField] public float _speed = 15;

    // Movement Inputs
    public Vector3 _moveDirection;

    // Mouse Position
    private Vector3 _mousePosition;

    private void Update()
    {
        // Inputs
        GatherInput();

        // Player Rotation
        Aim();
    }

    private void Start()
    {
        // Cache the camera, Camera.main is an expensive operation.
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        // Movement
        Move();
    }

    // Inputs for Movement
    private void GatherInput()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
    }

    // Code for Aim/Mouse
    private void Aim()
    {
        // Inputs Mouse Position in Game
        Vector2 mouseScreenPos = Input.mousePosition;

        // Distance of the Mouse Cursor in game from Camera
        Vector3 mousePos = new Vector3(mouseScreenPos.x, mouseScreenPos.y, 1000);

        // Transforms mouse world position to game Camera
        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(mousePos);

        // Player looks towards the mouse as it moves
        var direction = mouseWorldPos - transform.position;

        // Ignore the height difference.
        direction.y = 0;

        // Make the transform look in the direction.
        transform.forward = direction;
    }

    private void Move()
    {
        controller.Move(_moveDirection * _speed * Time.deltaTime);
    }
}
