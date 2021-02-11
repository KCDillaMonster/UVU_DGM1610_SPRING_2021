using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Set speed for the player
    public float speed = 20.0f;
    //Create variable for the players inputs
    public float hInput;
    //xRange boundary limit
    private float xRange = 23;
    //GambeObject for the projectile food
    public GameObject projectilePreFab;

    // Update is called once per frame
    void Update()
    {   
        //Player input values
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);
        //Set up if statement that will constrict player movement when it reaches screens edge
        //Left side constrictions
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //Right side constrictions
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //Spawn the food projectile using a specified key
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Launch the projectile
            Instantiate(projectilePreFab, transform.position, projectilePreFab.transform.rotation);
        }
    }
}
