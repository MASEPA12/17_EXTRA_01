using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftY : MonoBehaviour
{
    public Rigidbody recollectableRb;
    public float speed;
    private PlayerControllerY playerControllerScript;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControllerY>();

        recollectableRb = GetComponent<Rigidbody>();

        //Debug.Log($"{transform.position.x}");

    }

    void Update()
    {
        float posOrneg = transform.position.x;

        //if my x is negative, quan se multipliqui per -1 serà positiva, ha d'anar a la dreta
        /*if(!playerControllerScript.gameOver && posOrneg * -1 == posOrneg)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            Debug.Log($"va a la esquerra ---{posOrneg}");

            //estava a la dreta, ha d'anar cap a l'esquerra
        }
        else */if(!playerControllerScript.gameOver && posOrneg -14 == 0) //es positiva
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

            //estava a l'esquerra, ha d'anar a la dreta
        }


        if (!playerControllerScript.gameOver && posOrneg - 14 != 0) //es negativa
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

            //estava a l'esquerra, ha d'anar a la dreta
        }

        // If object goes off screen that is NOT the background (is the bomb or the money), destroy it
        if (transform.position.x < -15 && (gameObject.CompareTag("Money") || gameObject.CompareTag("Bomb")))
        {
            Destroy(gameObject);
        }
    }
   
}