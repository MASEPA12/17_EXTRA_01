using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopsoundY : MonoBehaviour
{
    private AudioSource MyAudioSource;
    public PlayerControllerY playerControllerScript;

    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
        playerControllerScript = FindObjectOfType<PlayerControllerY>();
    }

    void Update()
    {   //if it is game over the music will stop
        if(playerControllerScript.gameOver)
        {
            MyAudioSource.Stop();
        }
    }
}
