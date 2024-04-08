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
    float rotY;
    float rotZ;

    void Start()
    {
        child0 = transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var vel = rb.velocity;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0)
        {
            vel.x = -Speed;
            rotY = 180;
            rotZ = -10;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0)
        {
            vel.x = Speed;
            rotY = 0;
            rotZ = -10;
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
            rotZ = 0;
        }
        child0.rotation = Quaternion.Euler(0, rotY, rotZ);

        var pos = transform.position;
        bool isGrounded = false;
        isGrounded |= Physics.Raycast(new Vector3(pos.x - 0.4f, pos.y, pos.z), new Vector3(0, -1, 0), 1.1f);
        // Debug.DrawRay(new Vector3(pos.x - 0.4f, pos.y, pos.z), new Vector3(0, -1.1f, 0), Color.red);
        isGrounded |= Physics.Raycast(new Vector3(pos.x + 0.4f, pos.y, pos.z), new Vector3(0, -1, 0), 1.1f);
        // Debug.DrawRay(new Vector3(pos.x + 0.4f, pos.y, pos.z), new Vector3(0, -1.1f, 0), Color.green);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            if (isGrounded)
            {
                vel.y = JumpVel;
            }
        }

        rb.velocity = vel;
    }
}
