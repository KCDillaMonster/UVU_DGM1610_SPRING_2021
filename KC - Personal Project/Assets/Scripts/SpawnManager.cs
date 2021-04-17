using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // List for zombie prefabs to generate
    public GameObject[] zombiePrefabs;
    //List for powerup prefabs to generate
    public GameObject[] powerupPrefabs;
    //Spawn range on map for x and z
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    //Start and proggressing delays on zombie and powerup generation
    private float zombieStartDelay = 2.0f;
    private float zombieSpawnInterval = 1.5f;
    private float powerupStartDelay = 5.0f;
    private float powerupSpawnDelay = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomZombies", zombieStartDelay, zombieSpawnInterval);
        InvokeRepeating("SpawnRandomPowerups", powerupStartDelay, powerupSpawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomZombies()
    {
        Vector3 spawnPos = new Vector3(0.0f, 2.0f, 12.0f);
        int zombieIndex = Random.Range(0, zombiePrefabs.Length);
        Instantiate(zombiePrefabs[zombieIndex], spawnPos, zombiePrefabs[zombieIndex].transform.rotation);
    }
    void SpawnRandomPowerups()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex], spawnPos, powerupPrefabs[powerupIndex].transform.rotation);
    }
}
