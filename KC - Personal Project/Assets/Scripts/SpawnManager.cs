using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject zombiePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(zombiePrefabs, (0.0f, 2.0f, 12.0f), zombiePrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
