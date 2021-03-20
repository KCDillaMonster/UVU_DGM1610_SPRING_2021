using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //Creat Variables tied to behavior
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //Background position
        startPos = transform.position;
        //Find half of the background size
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //If statment for when the background position hits the halfway mark
        if(transform.position.x < startPos.x - repeatWidth)
        {
            //Repeat the background
            transform.position = startPos;
        }
    }
}
