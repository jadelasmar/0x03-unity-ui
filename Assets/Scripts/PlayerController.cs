using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 800.0f;
    private int score = 0;
    public int health = 5;
    public AudioClip winSound;
    public AudioClip gameOverSound;
    public AudioClip coinSound;
    public Animator animator;
    private int levelToLoad;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

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
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + score.ToString());
        }

        if (other.gameObject.CompareTag("Trap"))
        {

            AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            health--;
            Debug.Log("Health: " + health.ToString());
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            AudioSource.PlayClipAtPoint(winSound, transform.position);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            health = 5;
            score = 0;
        }
    }
}
