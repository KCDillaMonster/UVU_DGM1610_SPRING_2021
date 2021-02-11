using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //variable with the speed value
    private float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        //Creates the speed of the moving object
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
