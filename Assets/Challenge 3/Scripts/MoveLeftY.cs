using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftY : MonoBehaviour
{
    public float speed;
    private PlayerControllerY playerControllerScript;
    private float leftBound = -10;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControllerY>();
    }

    void Update()
    {
        // If game is not over and the object is in the right side of the screen, move to the left
        if (!playerControllerScript.gameOver && transform.position.x >= 12)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        // If game is not over and the object is in the left side of the screen, move to the right
        /*if (!playerControllerScript.gameOver && transform.position.x <= -12)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }*/ 

        // If object goes off screen that is NOT the background (is the bomb or the money), destroy it
        if (transform.position.x < leftBound && (gameObject.CompareTag("Money") || gameObject.CompareTag("Bomb")))
        {
            Destroy(gameObject);
        }
    }
}