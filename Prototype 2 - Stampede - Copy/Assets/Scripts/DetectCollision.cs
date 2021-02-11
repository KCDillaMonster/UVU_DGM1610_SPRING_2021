using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        //Destroy the object and collider on trigger
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
