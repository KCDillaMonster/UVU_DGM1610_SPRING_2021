using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables to store player speed, turn speed, jumping force, and gravity
    public float speed = 10.0f, rotationSpeed = 20.0f, turnSpeed = 10.0f, jumpForce = 30.0f, gravityMod = 7.0f;
    // where the constraints on the map will be located.
    private float zRange = 48.0f, xRange = 48.0f;
    //variables to use for the player inputs for movement
    private float vInput;
    // players rigid body to use for certain functions
    public GameObject focalPoint;
    private Rigidbody playerRb;
    // variable for particles effects
    public ParticleSystem invulnerableParticle;
    // boolean for if the player is on the ground, boolean for if the game if over, boolean for if the player has a powerup
    private bool isOnGround = true, isGameOver = false, hasPowerup;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body of the player
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        // apply gravity to the physics of the game
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        // Call functions for moving the player and constraints
        MovePlayer();
        PlayerConstraints();
    }
    void MovePlayer()
    {
        if(isGameOver == false)
        {
            // gathers players inputs and controls
            vInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            // describe what happens when inputs are put in
            transform.Translate(focalPoint.transform.forward * Time.deltaTime * speed * vInput);
            focalPoint.transform.Rotate(Vector3.up,  horizontalInput * rotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up,  horizontalInput * rotationSpeed * Time.deltaTime);
            // spacebar input results in jump
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                // while player is in the air, change boolean to keep from added jumping
                isOnGround = false;
            }
        }
    }
    void PlayerConstraints()
    {
        // forward constraints
        if (transform.position.z > zRange)
        {
         transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        // backward constraints
        if (transform.position.z < -zRange)
        {
         transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        // right constraints
        if (transform.position.x > xRange)
        {
         transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // left constraints
        if (transform.position.x < -xRange)
        {
         transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // When the player hits the ground again, boolean turns to true
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        // If zombie collides with Player, destroy the player
        if(collision.gameObject.CompareTag("Zombie") && hasPowerup == false)
        {
            isGameOver = true;
            Debug.Log("Game Over");
        }
        // If the player has Invulnerable Powerup, destroy zombie
        if(collision.gameObject.CompareTag("Zombie") && hasPowerup == true)
        {
            Destroy(collision.gameObject);
            Debug.Log("Zombie Destroyed");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // If statement for when the player picks up a powerup and destroys it
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            
            Destroy(other.gameObject);
            Debug.Log("Powerup Collected!");
            //Play the powerup particle effect
            invulnerableParticle.Play();
            //Run the countdown for the powerup's power
            StartCoroutine(PowerupCountdownRoutine());
        }
        else
        {
            invulnerableParticle.Stop();
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        //Countdown for the powerups effects
        yield return new WaitForSeconds(7); hasPowerup = false;
    }
}
