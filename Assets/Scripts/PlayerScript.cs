using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var vel = rb.velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -10;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = 10;
        }
        else
        {
            vel.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vel.y = 10;
        }
        rb.velocity = vel;
    }
}
