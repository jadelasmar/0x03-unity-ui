using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(0,0,speed);
        }
        if(Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0,0,-speed);
        }
        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-speed,0,0);
        }
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(speed,0,0);
        }
        
    }
}
