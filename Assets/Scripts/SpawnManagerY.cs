using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerY : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    private PlayerControllerY playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = FindObjectOfType<PlayerControllerY>();
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        // x= random number between A, B --> A=random number between -14,-12 / B=random btween 12,14

        Vector3 spawnLocationR = new Vector3(-14, Random.Range(-7, 7), 0);
        Vector3 spawnLocationL = new Vector3(14, Random.Range(-7, 7), 0);
        

        int index = Random.Range(0, objectPrefabs.Length);
        
        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocationL, objectPrefabs[index].transform.rotation);
            Instantiate(objectPrefabs[index], spawnLocationR, objectPrefabs[index].transform.rotation);
        }
    }
}
