using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    
    private Vector3 _input;

    public ShootProjectile shootProjectile;
    public Upgradeables upgrades;

    public InventoryUIHandler inventoryUIHandler;
    public MousePosition mousePos;

    private void Start()
    {


        shootProjectile.GetComponent<ShootProjectile>();
        upgrades.GetComponent<Upgradeables>();
    }

    private void Update()
    {
        if (inventoryUIHandler.InventoryOpen == false)
        {
            GatherInput();
            Aim();
            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("Shot");
                shootProjectile.ComponentShoot();
            }
        }

        
    }

    private void Aim()
    {
        //// Inputs Mouse Position in Game
        //Vector2 mouseScreenPos = Input.mousePosition;

        //// Distance of the Mouse Cursor in game from Camera
        //Vector3 mousePos = new Vector3(mouseScreenPos.x, mouseScreenPos.y, 1000);

        //// Transforms mouse world position to game Camera
        //Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(mousePos);

        //// Player looks towards the mouse as it moves
        var direction = mousePos.WorldPosition - transform.position;

        //// Ignore the height difference.
        direction.y = 0;

        //// Make the transform look in the direction.
        transform.forward = direction;
    }


    private void FixedUpdate()
    {
        if (inventoryUIHandler.InventoryOpen == false)
            Move();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
}



