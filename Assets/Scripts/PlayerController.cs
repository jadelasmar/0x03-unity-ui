using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 800.0f;
    private int score = 0;
    public int health = 5;
    public AudioClip winSound;
    public AudioClip gameOverSound;
    public AudioClip coinSound;
    private int levelToLoad;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;
    public GameObject winLose;



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
            SetScoreText();
            other.gameObject.SetActive(false);
            //Debug.Log("Score: " + score.ToString());
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            SetHealthText();
            //Debug.Log("Health: " + health.ToString());
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            AudioSource.PlayClipAtPoint(winSound, transform.position);
            StartCoroutine(LoadScene(3));
            SetWinText();
            //Debug.Log("You win!");
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (health == 0)
        {
            //Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
            health = 5;
            score = 0;
            SetLoseText();
        }
    }

    void SetScoreText()
    {
        scoreText.text="Score: "+score.ToString();

    }
    void SetHealthText()
    {
        healthText.text="Health: "+health.ToString();

    }
    void SetWinText()
    {
        winLose.SetActive(true);
        winLoseText.text="You Win!";
        winLoseText.color = Color.black;
        winLoseBG.color = Color.green;
    }
    void SetLoseText()
    {
        winLose.SetActive(true);
        winLoseText.text="Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}