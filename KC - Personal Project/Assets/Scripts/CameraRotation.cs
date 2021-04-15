using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed;
    public float xCameraRange;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       float horizontalInput = Input.GetAxis("MouseX");
       float verticalInput = Input.GetAxis("MouseY");
       
       transform.Rotate(Vector3.up,  horizontalInput * rotationSpeed * Time.deltaTime);
       transform.Rotate(Vector3.right,  verticalInput * rotationSpeed * Time.deltaTime);
    }
}
