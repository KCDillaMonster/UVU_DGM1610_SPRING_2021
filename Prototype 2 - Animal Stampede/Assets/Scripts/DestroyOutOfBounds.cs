using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 35;
    private float lowerBound = -15;
  
    // Update is called once per frame
    void Update()
    {   
        //Destrays the gameobject when it reaches a certain z position in the game
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBound)
        {
            Debug.Log("GAME OVER!");
            Destroy(gameObject);
        }
    }
}
