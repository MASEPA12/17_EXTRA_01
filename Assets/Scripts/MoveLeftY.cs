using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftY : MonoBehaviour
{
    public float speed;
    private PlayerControllerY playerControllerScript;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControllerY>();

        float posOrneg = transform.position.x;

            /*if the object is in the right side of the screen {ex:(14,7,0) 14-14=0}
            vector left is multiplied by the inverted sign of the speed*/
        if (!playerControllerScript.gameOver && posOrneg - 14 == 0) 
        {
            speed = speed * -1;
            //R to L
        }
    }

    void Update()
    {
            //otherwise, if the object is in the left side -14-14 !=0 // L to R
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        // If object goes off screen that is NOT the background (is the bomb or the money), destroy it
        if ((transform.position.x < -15 || transform.position.x > 15) && (gameObject.CompareTag("Money") || gameObject.CompareTag("Bomb")||gameObject.CompareTag("SpecialMoney")))
        {
            Destroy(gameObject);
        }
    }
   
}