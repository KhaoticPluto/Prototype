using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTest : MonoBehaviour
{
    movement _script;

    //Dash Terms
    public float _dashSpeed = 20f;
    public float _dashTime = 0.25f;
    private float _dashCooldown = 2f;

    private void Start()
    {
        _script = GetComponent<movement>();
    }

    private void Update()
    {
        // Dash Inputs
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + _dashTime)
        {
            _script.controller.Move(_script._moveDirection * _dashSpeed * Time.deltaTime);

            yield return null;

        }
    }
}
