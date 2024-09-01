using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f; // The force applied to the ball when making it go up
    [SerializeField]
    private List<Color> availableColors; // The colors the player can have
    [SerializeField]
    private GameObject gameoverPanel;
    [SerializeField]
    private GameObject victoryPanel;
    [SerializeField]
    public GameObject starEffectPrefab; // Reference to the star particle effect prefab


    // The different audio clips to play.
    [SerializeField]
    private AudioClip gameoverAudio;
    [SerializeField]
    private AudioClip colorSwitchAudio;
    [SerializeField]
    private AudioClip starAudio;
    [SerializeField]
    private AudioClip winAudio;
    //The volume for each audio
    [SerializeField]
    private float gameoverVolume = 0.7f;
    [SerializeField]
    private float colorSwitchVolume = 0.7f;
    [SerializeField]
    private float starVolume = 0.7f;
    [SerializeField]
    private float winVolume = 0.7f;


    private Rigidbody2D rb;
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private CircleCollider2D col;
    private AudioSource audioSource;
    

    void Start()
    {
        // Get the components attached to the ball
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();

        // Set a random color to the ball with the list of available colors given
        sr.color = availableColors[Random.Range(0, availableColors.Count)];
    }

    void Update()
    {
        // Check for mouse click or screen tap input
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0) // Mouse click or first touch
        {
            // Reset the vertical velocity
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            // Apply an upward force to the ball
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check the tag of the collided object
        switch (collision.gameObject.tag)
        {
            // If the tag of the object is Obstacle, then we compare the ball's color and the obstacle's color
            case "Obstacle":
                Color ballColor = sr.color; // The ball color
                Color obstacleColor = collision.gameObject.GetComponent<SpriteRenderer>().color; // The obstacle color

                // We check if the two colors are not the same.
                if (!ballColor.Equals(obstacleColor))
                {
                    GameOver(); // The ball hit the wrong color and the game is lost
                }
                break;

            // If the tag of the object is ColorSwitch, then we change the ball's color
            case "ColorSwitch":
                    Color newColor = availableColors[Random.Range(0, availableColors.Count)]; // Get a random color from the colors available

                    // As long as the new color we got is the same as the one we actually have, we try to get another color
                    while (newColor == sr.color)
                        newColor = availableColors[Random.Range(0, availableColors.Count)]; 

                    sr.color = newColor; // Set the new color

                    // We play the sound of collecting a color switch
                    audioSource.PlayOneShot(colorSwitchAudio, colorSwitchVolume);
                    Destroy(collision.gameObject); // Destroy the color switch
                break;
                
            // If the tag of the object is Star, then we increment the score and delete the star
            case "Star":
                    // Find the ScoreManager in the scene and add score
                    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

                    if (scoreManager != null)
                    {
                        scoreManager.AddScore(1);
                    }

                    // Instantiate the particle effect at the position of the star
                    if (starEffectPrefab != null)
                    {
                        Instantiate(starEffectPrefab, collision.gameObject.transform.position, Quaternion.identity);
                    }


                    // We play the sound of collecting a star
                    audioSource.PlayOneShot(starAudio, starVolume);
                    Destroy(collision.gameObject); // Destroy the star
                break;

            // If the tag of the object is LevelEnd, then we destroy the player and display the victory pannel
            case "LevelEnd":
                    EndLevel();
                break;
            
            default:
                break;
        }
    }


    void GameOver()
    {
        ps.Play();  // Play the particle system of the ball
        audioSource.PlayOneShot(gameoverAudio, gameoverVolume); // We play the Game Over Sound
        sr.enabled = false; // Hide the sprite of the ball
        rb.constraints = RigidbodyConstraints2D.FreezePosition; // Freeze the ball's position
        col.enabled = false; // We disable the collider
        gameoverPanel.SetActive(true);
    }

    void EndLevel()
    {
        audioSource.PlayOneShot(winAudio, winVolume); // We play the sound of winning the level
        sr.enabled = false; // Hide the sprite of the ball
        rb.constraints = RigidbodyConstraints2D.FreezePosition; // Freeze the ball's position
        col.enabled = false; // We disable the collider
        victoryPanel.SetActive(true);
    }
}
