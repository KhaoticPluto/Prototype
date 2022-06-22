using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTest : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]public float _dashSpeed;
    [SerializeField]private float _dashTime;
    public float startDashTime;
    private Vector3 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _dashTime = startDashTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash) //When pressing LeftShift and you can dash
        {
            _isDashing = true;
            _canDash = false;
            _dashingDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_dashingDir == Vector3.zero)
            {
                _dashingDir = new Vector3(transform.localScale.x, 0, transform.localScale.z);
            }
            StartCoroutine(StopDashing());
        }

        if (_isDashing) //Dashing Stops
        {
            _rb.velocity = _dashingDir.normalized * _dashSpeed;
            return;
        }
    }
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashTime);
        _isDashing = false;
    }

}
