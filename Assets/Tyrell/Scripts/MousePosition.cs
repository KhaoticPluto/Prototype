using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{


    public Vector3 ScreenPosition;
    public Vector3 WorldPosition;
    

    // Update is called once per frame
    void Update()
    {
        ScreenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(ScreenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitData))
        {
            WorldPosition = hitData.point;
        }

        
        
    }
}
