using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Zombie's speed
    public float enemySpeed = 8.0f;
    public PlayerController playerControllerScript;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Find player object for zombies to chase
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Send the zombies running after player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * Time.deltaTime * enemySpeed);
    }
}
