using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyScript : MonoBehaviour
{
    const float Speed = 2.5f;

    Transform child0;
    int dir = -1;
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

        if (dir < 0)
        {
            vel.x = -Speed;
            rotY = 180;
            rotZ = -5;
        }
        else if (dir > 0)
        {
            vel.x = Speed;
            rotY = 0;
            rotZ = -5;
        }
        child0.rotation = Quaternion.Euler(0, rotY, rotZ);

        bool isHit = Physics.Raycast(transform.position, new Vector3(dir, 0, 0), out RaycastHit hitInfo, 0.35f);
        // Debug.DrawRay(transform.position, new Vector3(0.35f * dir, 0, 0), Color.green);
        if (isHit && !hitInfo.transform.name.StartsWith("Player"))
        {
            dir *= -1;
        }

        rb.velocity = vel;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.StartsWith("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
