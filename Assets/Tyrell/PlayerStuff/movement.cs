using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Camera
    private Camera mainCam;
    [SerializeField] private LayerMask ground;

    // Player Movement Terms
    [SerializeField] public CharacterController controller;

    //ShootProjectile script
    public ShootProjectile shootProjectile;

    // Dash
    public float _dashCooldown;
    public bool _isDashing;

    // Movement Inputs
    private Vector3 _moveDirection;

    // Mouse Position
    public MousePosition mousePos;

    //InventoryHandler
    public InventoryUIHandler inventoryUIHandler;

    //Upgradeables
    public Upgradeables upgrade;

    private void Update()
    {
        if (inventoryUIHandler.InventoryOpen == false)
        {
            //Input
            GatherInput();
            //Aim
            Aim();

            //Shoots projectile from shootprojectile script
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
                shootProjectile.ComponentShoot();
            }
        }


    }

    private void Start()
    {
        inventoryUIHandler = FindObjectOfType<InventoryUIHandler>();

        // Cache the camera, Camera.main is an expensive operation.
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        //Movement
            if (inventoryUIHandler.InventoryOpen == false)
                Move();
    }

    // Inputs for Movement
    private void GatherInput()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_dashCooldown <= 0)
            {
                StartCoroutine(Dash());
                _isDashing = true;
            }
        }

        _dashCooldown -= Time.deltaTime;
    }

    // Code for Aim/Mouse
    private void Aim()
    {
        
        // Player looks towards the mouse as it moves
        var direction = mousePos.WorldPosition - transform.position;

        // Ignore the height difference.
        direction.y = 0;

        // Make the transform look in the direction.
        transform.forward = direction;

        
    }

    private void Move()
    {
        controller.Move(_moveDirection * upgrade.playerSpeed * Time.deltaTime);
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + upgrade._dashTime)
        {
            controller.Move(_moveDirection * upgrade._dashSpeed * Time.deltaTime);
            _dashCooldown = upgrade._dashCooldownTime;
            _isDashing = false;
            yield return null;
        }
    }


    

}


public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 _moveDirection) => _isoMatrix.MultiplyPoint3x4(_moveDirection);
}
