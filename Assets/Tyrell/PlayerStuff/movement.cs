using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    #region singleton
    public static movement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

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


    //analytics stuff
    Vector3 lastPos;
    float DetectMovement;
    public int HowMuchPlayerMoved = 0;
    public int HowMuchPlayerStill = 0;
    float Timer = 0;
    int DelayAmount = 1;

    private void Update()
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

        if (transform.position != lastPos)
        {
            //Player has Moved
            DetectMovement = 1;
        }
        else
        {
            //Player has not Moved
            DetectMovement = 0;
        }

        

        Timer += Time.deltaTime;

        if(Timer > DelayAmount)
        {
            Timer = 0;
            if (DetectMovement == 1)
            {
                HowMuchPlayerMoved++;
                
            }
            if (DetectMovement == 0)
            {
                HowMuchPlayerStill++;
                
            }

        }

        
    }

    private void Start()
    {
        inventoryUIHandler = FindObjectOfType<InventoryUIHandler>();

        
    }

    private void FixedUpdate()
    {
        lastPos = transform.position;
        //Movement
        //if (inventoryUIHandler.InventoryOpen == false)
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
        controller.Move(_moveDirection.ToIso() * upgrade.playerSpeed * Time.deltaTime);
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



