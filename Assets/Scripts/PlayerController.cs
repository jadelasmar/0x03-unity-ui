using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 15;
    private int score = 0;
    public int health = 5;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(0, 0, speed);
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -speed);
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-speed, 0, 0);
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(speed, 0, 0);
        }

    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score.ToString());
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health.ToString());
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            
            health = 5;
            score = 0;
        }

    }
}
