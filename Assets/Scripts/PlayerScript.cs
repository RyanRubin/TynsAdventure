using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    const float Deceleration = 20;
    const float JumpVel = 10;
    const float Speed = 5;

    Transform child0;
    Rigidbody rb;

    void Start()
    {
        child0 = transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var vel = rb.velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
            child0.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
            child0.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            if (vel.x < 0)
            {
                vel.x += Deceleration * Time.deltaTime;
                if (vel.x > 0)
                {
                    vel.x = 0;
                }
            }
            else if (vel.x > 0)
            {
                vel.x -= Deceleration * Time.deltaTime;
                if (vel.x < 0)
                {
                    vel.x = 0;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vel.y = JumpVel;
        }
        rb.velocity = vel;
    }
}
