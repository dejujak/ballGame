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

        /*//GetKey�� ���� ������
        GetKeyControl();*/

        //GetAxis�� ���� ������
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
        //-1~+1 ������ float���� ����
        float inputX = Input.GetAxis("Horizontal");

        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = playerRigidbody.velocity.y; //���� y�� �ӵ� ����

        /*//AddForce�� �̿��� ������
        playerRigidbody.AddForce(inputX*speed,0, inputZ*speed);*/

        //Velocity�� �̿��� ������
        Vector3 velocity=new Vector3(inputX,0,inputZ);
        velocity=velocity*speed;

        velocity.y = fallSpeed; //y�� �ӵ� ����

        playerRigidbody.velocity = velocity;
        
    }
}
