﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerY : MonoBehaviour
{
    public bool gameOver;

    [SerializeField] private int points;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip powerUpSound;
    public AudioClip explodeSound;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    void Update()
    {
        //MOVEMENT; If space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
        //UPPER LIMIT; if the y pos is greater than 8, rigidbody velocity is 0
        if (transform.position.y > 8)
        {
            playerRb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        //if player collides with the ground, explode and set gameOver to true
        else if (other.gameObject.CompareTag("GROUND"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        // if player collides with money, fireworks
        if (other.gameObject.CompareTag("Money"))
        {
            points++;
            Debug.Log($"TOTAL SCORE: {points}");
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        //if player collides with money, +5 points, special sound, fireworks
        else if (other.gameObject.CompareTag("SpecialMoney"))
        {
            points = points + 5;
            Debug.Log($"TOTAL SCORE: {points}");
            fireworksParticle.Play();
            playerAudio.PlayOneShot(powerUpSound, 1.0f);
            Destroy(other.gameObject);
        }
    }
}
