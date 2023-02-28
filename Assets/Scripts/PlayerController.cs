using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FloatingJoystick joystick;

    public float moveSpeed;

    public float rotateSpeed;

    public Vector3 mouseStartPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(joystick.Vertical)>.1f || Mathf.Abs(joystick.Horizontal)>.1f)
        {
            var dir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            transform.forward = dir;
            transform.position += dir.normalized * Time.deltaTime * moveSpeed;
        }
        

        
        
    }

    
}
