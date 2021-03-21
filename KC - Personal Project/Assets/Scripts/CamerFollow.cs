using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    // player variable for camera to act with
    public GameObject Player;
    // set the camera a little bit away from the player for better view
    private Vector3 offset = new Vector3(0, 2, -3);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // use the player position to move the camera while staying offset
        transform.position = Player.transform.position + offset;
    }
}
