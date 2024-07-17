using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 10f;
    Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(gameManager.isGameOver)
        {
            return;
        }

        /*//GetKey를 통한 움직임
        GetKeyControl();*/

        //GetAxis를 통한 움직임
        GetAxisControl();
    }

    public void GetKeyControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.AddForce(0, 0, speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.AddForce(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.AddForce(0, 0, -speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.AddForce(speed, 0, 0);
        }
    }

    public void GetAxisControl()
    {
        //-1~+1 사이의 float값을 리턴
        float inputX = Input.GetAxis("Horizontal");

        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = playerRigidbody.velocity.y; //원래 y의 속도 보존

        /*//AddForce를 이용한 움직임
        playerRigidbody.AddForce(inputX*speed,0, inputZ*speed);*/

        //Velocity를 이용한 움직임
        Vector3 velocity=new Vector3(inputX,0,inputZ);
        velocity=velocity*speed;

        velocity.y = fallSpeed; //y의 속도 보존

        playerRigidbody.velocity = velocity;
        
    }
}
