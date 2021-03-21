using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables to store player speed, turn speed, jumping force, and gravity
    public float speed = 10.0f;
    public float turnSpeed = 10.0f;
    public float jumpForce = 30.0f;
    public float gravityMod = 7.0f;
    // where the constraints on the map will be located.
    private float zRange = 48.0f;
    private float xRange = 48.0f;
    //variables to use for the player inputs
    private float hInput;
    private float vInput;
    // players rigid body to use for certain functions
    private Rigidbody playerRb;
    // boolean for if the player is on the ground
    private bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body of the player
        playerRb = GetComponent<Rigidbody>();
        // apply gravity to the physics of the game
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerConstraints();
    }
    void MovePlayer()
    {
        // gathers players inputs and controls
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // describe what happens when inputs are put in
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);
        transform.Translate(Vector3.right * turnSpeed * hInput * Time.deltaTime);
        // spacebar input results in jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // while player is in the air, change boolean to keep from added jumping
            isOnGround = false;
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
        // when the player hits the ground again, boolean turns to true
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
