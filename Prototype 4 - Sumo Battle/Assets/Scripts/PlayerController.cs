using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 100;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    private bool hasPowerup;
    private float powerupStrength = 16.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * Time.deltaTime);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    //Allows the player to pickup powerup and remove the object from view
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            Debug.Log("Powerup Collected!");
            //Run the countdown for the powerup's power
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //Gets the enemy's rigidbody for physics properties
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            //Gets the position of the enemy in relatio to the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            //Report player collision with pickup
            Debug.Log("Player has collided with " + collision.gameObject + " with powerup set to " + hasPowerup);
            //Adds force to the enemy's rigidbody using the before formulas
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
