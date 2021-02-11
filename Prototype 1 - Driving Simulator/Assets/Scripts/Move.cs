using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Access Modifier, Data Type, Name
    private float speed = 30.0f;
    private float turnSpeed = 20.0f;

    private float hInput;
    private float fInput;

    // Update is called once per frame
    void Update()
    {
        // Gathers the inputs for the controls
        hInput = Input.GetAxis("Horizontal");
        fInput = Input.GetAxis("Vertical");
        // Makes the Vehicle go forward and back
        transform.Translate(Vector3.forward * Time.deltaTime * speed * fInput);
        // Makes the Vehicle go left and right
        transform.Rotate(Vector3.up, turnSpeed * hInput * Time.deltaTime);
    }
}
