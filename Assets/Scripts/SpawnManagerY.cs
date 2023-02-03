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
        //SPAWN RANDOM RECOLLECTABLES EVERY CERTAIN TIME
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = FindObjectOfType<PlayerControllerY>();
    }

    void SpawnObjects()
    {
        //creatoin of two (right and left) new vectors with random high (y axis) 
        Vector3 spawnLocationR = new Vector3(-14, Random.Range(-7, 7), 0);
        Vector3 spawnLocationL = new Vector3(14, Random.Range(-7, 7), 0);
        
        //set random index (for spawning a random obstacle)
        int index = Random.Range(0, objectPrefabs.Length);
        
        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocationL, objectPrefabs[index].transform.rotation);
            Instantiate(objectPrefabs[index], spawnLocationR, objectPrefabs[index].transform.rotation);
        }
    }
}
